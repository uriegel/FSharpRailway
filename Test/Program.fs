open FSharpRailway
open Railway
open Option

printfn "Hello from F#"

let add x = x + 1

let test = tee add 3

let getInt i = Some i

let stringFromIntOption (i: int) = Some (i.ToString ())

let stringFromInt (i: int) = i.ToString ()


let f i = 
    getInt i
    |> Option.bind stringFromIntOption

let fi i = 
    i |> getInt >>= stringFromIntOption

let fa = getInt >=> stringFromIntOption

// let getString = stringFromIntOption >>= getInt 9
//let getString2 = getInt 9 >>= stringFromInt

