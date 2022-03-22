module Assignment3

open helpers.helpers

type State = { Zeroes:int; Ones:int }

let countChars acc item =
    match item with
    | '0' -> { acc with Zeroes = acc.Zeroes + 1 }
    | '1' -> { acc with Ones = acc.Ones + 1 }
    | _ -> failwith "Not a binary char"

type CalcType = 
| Gamma
| Epsilon

let calc item t =
    if item.Zeroes < item.Ones
    then match t with
         | Gamma -> 1
         | Epsilon -> 0
    else match t with 
         | Gamma -> 0
         | Epsilon -> 1

let frombinary lst =
    let rec loop acc n l =
        if Seq.isEmpty l then acc
        else loop (acc + (calc (Seq.head l) * (pown 2 n))) (n + 1) (Seq.tail l)
    loop 0 1 lst
         
let run1 filePath =
    let lst = 
        readLines filePath
        |> Seq.map (fun l -> l.ToCharArray())
        |> Seq.transpose
        |> Seq.map (Seq.fold countChars { Zeroes = 0; Ones = 0})
        |> Seq.toArray  
        
        
    lst    
    |> frombinary
    |> printf "%i"

    0
    //|> printf "%A"
