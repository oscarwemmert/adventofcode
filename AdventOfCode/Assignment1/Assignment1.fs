module Assignment1

open helpers.helpers

let countIncreases acc item prev =
    match prev with
    | Some prev when item > prev -> acc + 1 
    | _ -> acc

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