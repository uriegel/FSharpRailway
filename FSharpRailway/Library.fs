namespace FSharpRailway

module Railway =

    /// <summary>
    /// Helper function for composing functions (Railway Oriented Programming). 
    /// Slot for  dead end function (Inject side effects in function coposition pipeline)
    /// </summary>
    /// <param name="f">function with one input parameter 'a. This is the dead end function</param>
    /// <param name="x">input parameter 'a</param>
    /// <returns>'a</returns>
    let tee f x =
        f x |> ignore
        x       

    /// <summary>
    /// Takes the first element of a tuple disgarding the second
    /// </summary>
    /// <param name="a, _">Tuple of two elements</param>
    /// <returns>The first tuple element a</returns>
    let takeFirstTupleElem (a, _) = a

    module Async = 

        let (>>) f g x = async {
                let! y = f x
                let! e = g y
                return e
            }
