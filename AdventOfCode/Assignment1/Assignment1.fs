﻿module Assignment1

type State<'TAcc, 'TItem> = { Acc:'TAcc; Prev:'TItem option }

let readLines filePath = System.IO.File.ReadLines(filePath)

let countIncreases acc item prev =
    match prev with
    | Some prev when item > prev -> acc + 1 
    | _ -> acc

let foldprev f init l =
    let folder state item =
        { Acc = (f state.Acc item state.Prev); Prev = Some item  }
    let res = Seq.fold folder { Acc = init; Prev = None } l
    res.Acc    

let run1 filepath =
   readLines filepath
   |> Seq.map int
   |> foldprev countIncreases 0
   |> printf "%i"
   0

let sumRollingWindows (l : int list) = seq {
    for i in [0 .. (max 0  l.Length-3)] do
        yield l[i] + l[i+1] + l[i+2]
}

let sumRollingWindows2 lst =
    let rec loop l acc = 
        match l with
        | a::b::c::_ & _::tail -> loop tail (a + b + c::acc)
        | _ -> acc
    loop lst [] |> List.rev 

let run2 filepath =
    readLines filepath 
    |> Seq.map int
    |> Seq.toList
    |> sumRollingWindows2
    |> foldprev countIncreases 0
    |> printf "%i"
    0