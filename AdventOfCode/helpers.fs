
namespace helpers

module helpersinternal =
    type State<'TAcc, 'TItem> = { Acc:'TAcc; Prev:'TItem option }

module helpers =
    open helpersinternal

    let readLines filePath = System.IO.File.ReadLines(filePath)

    let foldprev f init l =
        let folder state item =
            { Acc = (f state.Acc item state.Prev); Prev = Some item  }
        let res = Seq.fold folder { Acc = init; Prev = None } l
        res.Acc


