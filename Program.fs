// Learn more about F# at http://fsharp.org

open System

let myInt = 5
let mutable myInt2 = 5
let myFloat:float = 5.
let myString = "Hello World"
let myBool = true
let myBool2 = not myBool
let myList1 = [1;2;3;4;5]
let myList2 = [1..10]
let myList3 = [0..5..100]
let myList4 = [0.0 .. 0.1 ..1.0]
let myList5 = ["apple", "orange", "pear"]
let myArray1 = [|1;2;3;4;5|]
let myArray2 = [|1..10|]

let square x = x * x
let hello name = sprintf "Hello %s" name
let age x = sprintf "Your age is %i" x
let loop1 min max = for i in min..max do printfn "%i" i    
let loop2 min max = [for i in min..max do i]
let loop3 min max = [ for i in min..max do if i % 2 = 0 then i ]

let function1 x y = x + y
let function2 (x:float) (y:float) :float = x + y

let mutableData =
    let mutable x = 10
    x <- 20
    x

let refData =
    let x = ref 42
    x := 20
    !x

let cylinderVolume r h = System.Math.PI * System.Math.Pow(r, 2.) * h
let small = cylinderVolume 2.
let large = cylinderVolume 3.

let describe list = 
    match list with
    | [x] -> sprintf "One element: %i" x
    | [x; y] -> sprintf "Two element: %i, %i" x y
    | _ -> sprintf "A longer list"

let head xs =
    match xs with
    | [] -> "empty"
    | h::_ -> sprintf "%i" h

let tail xs =
    match xs with
    | [] -> "empty"
    | _::t -> sprintf "%A" t    

let rec length xs =
    match xs with
    | [] -> 0
    | _::t -> 1 + length t   

let rec fact n =
    match n with
    | 0 -> 1
    | _ -> n * fact(n-1)

let rec fib n =
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> fib(n-1) + fib(n-2)

let list = [5;1;4;3;2]
let smaller x xs = xs |> List.filter(fun n -> n < x)
let larger x xs = xs |> List.filter(fun n -> n >= x)    

let rec quicksort xs =
    match xs with
    | [] -> []
    | x::xs ->
        let smaller = quicksort(xs |> List.filter(fun n -> n < x))
        let larger = quicksort(xs |> List.filter(fun n -> n >= x))
        smaller @ [x] @ larger

type Person = {
    FirstName:string
    LastName:string
}

let person1 = { 
    FirstName = "Surasuk"; 
    LastName = "Oakkharamonphong" 
}

open FSharp.Data

type Json = JsonProvider<"https://randomuser.me/api?results=10&nat=us">
let jsondata = Json.GetSample()

type Xml = XmlProvider<"https://devblogs.microsoft.com/dotnet/feed/">
let xmldata = Xml.GetSample()

type Csv = CsvProvider<"user.csv">
let csvdata = Csv.GetSample()

[<EntryPoint>]
let main argv =
    // for user in jsondata.Results do
    //     printfn "%s %s" user.Name.First user.Name.Last

    // for item in xmldata.Channel.Items do
    //     printfn "%s" item.Title

    for user in csvdata.Rows do
        printfn "%s %s" user.``Name.first`` user.``Name.last``

    0 // return an integer exit code
