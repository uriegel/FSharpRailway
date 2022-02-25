namespace FSharpRailway

module Helpers = 

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
