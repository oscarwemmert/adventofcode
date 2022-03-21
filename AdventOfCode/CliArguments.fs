module CliArguments

open Argu

type PartEnum =
| One
| Two

type Argument =
    | Assignment of number:int
    | Part of PartEnum
    interface IArgParserTemplate with
        member s.Usage = 
            match s with
            | Assignment _ -> "specify the assignment number"
            | Part _ -> "specify the part of the assignment"

let getArgs() =
    let parser = ArgumentParser.Create<Argument>()
    parser.ParseCommandLine()

let combinePath path =
    let basePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
    System.IO.Path.Join(basePath, path)