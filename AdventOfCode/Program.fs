open CliArguments

let args = CliArguments.getArgs()

exit (
    match (args.GetResult Assignment, args.GetResult Part) with
    | 1, One -> Assignment1.run1 (combinePath "Assignment1/input.txt")
    | 1, Two -> Assignment1.run2 (combinePath "Assignment1/input.txt")
    | 2, One -> Assignment2.run1 (combinePath "Assignment2/input.txt")
    | 2, Two -> Assignment2.run2 (combinePath "Assignment2/input.txt")
    | 3, One -> Assignment3.run1 (combinePath "Assignment3/input.txt")

)