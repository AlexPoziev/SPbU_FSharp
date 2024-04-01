module PhonebookTests

open NUnit.Framework
open Phonebook

[<Test>]
let addContact_WithCorrectContact_ShouldBeAdded () =
    let expectedResult = Contact("123", "321")
    
    let actualResult = (addContact ([], expectedResult))
    let element = actualResult.Head
    
    Assert.AreEqual(1, actualResult.Length)
    Assert.AreEqual(expectedResult, element)

[<Test>]
let findPhoneNumber_WithExistingContact_ShouldReturnNumberSuccessfully () =
    let expectedResult = Some "321"
    
    let result = findPhoneNumber ([("123", "321")], "123")
    
    Assert.AreEqual(expectedResult, result)

[<Test>]
let findName_WithExistingContact_ShouldReturnNameSuccessfully () =
    let expectedResult = Some "123"
    
    let result = findName ([("123", "321")], "321")
    
    Assert.AreEqual(expectedResult, result)

[<Test>]
let readPhonebookFromFile_WithExistingFile_ShouldReturnExpectedResult () =
    let expectedResult = [("123", "321"); ("321", "123")]
    
    let actualResult = readPhonebookFromFile "test.txt"
    
    Assert.AreEqual(Some expectedResult, actualResult)
    

[<Test>]
let writePhonebookToFile_WithCorrectData_ShouldAddDataInFile () =
    let path = "Phonebook.txt"
    let testData = [("123", "321")]
    
    writePhonebookToFile testData path
    let actualResult = readPhonebookFromFile path
    
    Assert.AreEqual(actualResult, Some testData)

[<Test>]
let findData_WithNotExistingContacts_ShouldReturnNone () =
    let actualName = findName ([], "123")
    let actualPhone = findPhoneNumber ([], "321")
    
    match (actualName, actualPhone) with
    | None, None -> Assert.Pass()
    | _ -> Assert.Fail()
    