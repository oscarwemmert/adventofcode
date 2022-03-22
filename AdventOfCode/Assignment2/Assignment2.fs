module Assignment2

open helpers.helpers
open System.Text.RegularExpressions

type Direction =
| Forward
| Up
| Down

let parseLine l = 
    let m = Regex.Match(l, @"([a-z]+) (\d+)")
    if not m.Success then failwith "No match"
    let dir = 
        match m.Groups[1].Value with
        | "forward" -> Forward
        | "down" -> Down
        | "up" -> Up
        | _ -> failwith "Bad value"
    (dir, int m.Groups[2].Value)

type Position = { Vertical:int; Horizontal:int; Aim:int }

let sumPosition (acc : Position) =
    function
    | Up, n -> { acc with Vertical = acc.Vertical - n }
    | Down, n -> { acc with Vertical = acc.Vertical + n }
    | Forward, n -> { acc with Horizontal = acc.Horizontal + n }

let sumPosition2 (acc : Position) =
    function
    | Up, n -> { acc with Aim = acc.Aim - n }
    | Down, n -> { acc with Aim = acc.Aim + n }
    | Forward, n -> { acc with Horizontal = acc.Horizontal + n; Vertical = acc.Vertical + acc.Aim * n }


let run1 filepath =
  readLines filepath
  |> Seq.map parseLine
  |> Seq.fold sumPosition { Vertical = 0; Horizontal = 0; Aim = 0 }
  |>  fun v -> printf "%A, mutiplied = %i" v (v.Vertical * v.Horizontal)
  0

let run2 filepath =
  readLines filepath
  |> Seq.map parseLine
  |> Seq.fold sumPosition2 { Vertical = 0; Horizontal = 0; Aim = 0 }
  |>  fun v -> printf "%A, mutiplied = %i" v (v.Vertical * v.Horizontal)
  0