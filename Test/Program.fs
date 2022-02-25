open FSharpRailway.Helpers
open FSharpRailway.Option
printfn "Hello from F#"

let add x = x + 1

let test = tee add 3

