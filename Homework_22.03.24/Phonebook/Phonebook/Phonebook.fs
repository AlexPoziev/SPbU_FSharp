module Phonebook
    
open System.IO

type Contact = string * string

let addContact ls contact = contact :: ls

let findName (ls: Contact list, phoneNumber: string) =
    match List.tryFind (fun x -> snd x = phoneNumber) ls with
    | Some x -> Some(fst x)
    | _ -> None

let findPhoneNumber (ls: Contact list, name: string) =
    match List.tryFind (fun x -> fst x = name) ls with
    | Some x -> Some(snd x)
    | _ -> None
    
let toString (contact: Contact) = fst contact + " " + snd contact
    
let contactByLine (str: string) =
    let elements = str.Split()

    if (elements.Length <> 2) then None
    else Some(Contact(elements[0], elements[1]))    

let rec printPhonebook phonebook =
    match phonebook with
    | head :: tail ->
        System.Console.WriteLine (head |> toString)
        printPhonebook tail
    | [] -> ()
    
let writePhonebookToFile phonebook path =
    let newList = phonebook |> List.map toString
    File.WriteAllLines (path, newList)

let readPhonebookFromFile path =      
    let contacts = File.ReadAllLines(path) |> Seq.map contactByLine
    if (Seq.contains None contacts) then None
    else Some(Seq.toList (contacts |> Seq.map (fun x -> match x with | Some x -> x)))
