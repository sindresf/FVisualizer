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

let rec processLines(lines) = 
    match lines with
    | [] -> []
    | currentLine::remaining ->
        let parsedLine = convertDataRow(currentLine)
        let parsedRest = processLines(remaining)
        parsedLine :: parsedRest

let testData = processLines ["test1,123";"Test2,456"]

let rec calculateSum(rows) =
    match rows with
    | [] -> 0
    | (_,value)::tail ->
        let remainingSum = calculateSum(tail)
        value + remainingSum

let sum1 = calculateSum(testData)

let piePiece = 123.0 / float(sum1) * 100.0

open System.IO

let lines = List.ofSeq(File.ReadAllLines(@"C:\Users\sindr\Source\Repos\PieCharter\PieCharter\data.csv"))

let data = processLines(lines)

let sum = float(calculateSum(data))

for(title,value) in data do
    let percentage = int((float(value)) / sum * 100.0)
    Console.WriteLine("{0,-18} - {1,8} ({2}%)",
                        title, value, percentage)



