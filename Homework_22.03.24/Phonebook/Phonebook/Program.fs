module Program

open System
open Phonebook

let printOptions () =
    Console.WriteLine(
    """
    Print number:
      0: Exit
      1: Add contact
      2: Find name by phone number
      3: Find phone number by name
      4: See all contacts
      5: Save phonebook in file
      6: Get phonebook from file
    """
    )
    
let startPhonebookApp =
    let rec helper (phonebook: Contact list) =
        printOptions ()
        match Console.ReadLine() with
        | "0" -> ()
        | "1" ->
            printfn "Write name and phone number divided by whitespace"                
            match contactByLine (Console.ReadLine()) with
            | Some x-> helper (addContact phonebook x)
            | None ->
                printfn "Incorrect input"
                helper phonebook
        | "2" ->
           printfn "Write phone number"
           match findName (phonebook, Console.ReadLine()) with
           | Some x -> printfn $"Name: {x}"
           | None -> printfn "Contact not found"
           helper phonebook
        | "3" ->
           printfn "Write name"
           match findPhoneNumber (phonebook, Console.ReadLine()) with
           | Some x -> printfn $"Phone number: {x}"
           | None -> printfn "Contact not found"
           helper phonebook
        | "4" ->
            printfn "Contacts:"
            printPhonebook phonebook
            helper phonebook
        | "5" ->
            printfn "Write path to file"
            let path = Console.ReadLine()
            
            writePhonebookToFile phonebook path
            helper phonebook
        | "6" ->
            printfn "Write path to file"
            let path = Console.ReadLine()
            match readPhonebookFromFile path with
            | Some x ->
                helper x
                printfn "Printed successfully"
            | None -> printfn "Error occurred while reading from the file"
        | _ ->
            printfn "Unexpected option"
            helper phonebook
    helper list.Empty
        
        
