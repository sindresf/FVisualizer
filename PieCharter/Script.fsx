// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "Library1.fs"
open PieCharter
open System

let convertDataRow(csvLine:string) =
    let cells = List.ofSeq(csvLine.Split(','))
    match cells with
    | title::number::_ -> 
        let parsedNumber = Int32.Parse(number)
        (title, parsedNumber)
    | _ -> failwith "Incorrect data format!"

convertDataRow("Testing reading,1234")

convertDataRow("Testing reading, 1234") //works with leading whitespace

