namespace FSharpRailway

module Result =

    /// <summary>
    /// Fish operator (Kleisli Category) for composing functions returning Result values (Railway Oriented Programming).
    /// </summary>
    /// <param name="f1">function with one input parameter 'a returning a Result&lt;'b&gt;</param>
    /// <param name="f2">function with one input parameter 'b returning a Result&lt;'c&gt;</param>
    /// <param name="x">input parameter 'a</param>
    /// <returns>function with one input parameter 'a returning a Result&lt;'c&gt;</returns>
    let (>=>) f1 f2 x =
        match f1 x with
        | Ok s    -> f2 s
        | Error e -> Error e

    /// <summary>
    /// Maps the Ok value by  calling function f, leaving the Err value
    /// <param name="f">function with one input parameter 'a returning 'b</param>
    /// <param name="x">input parameter Result&lt;'a&gt;</param>
    /// <returns>Result&lt;'b&gt;</returns>
    let map f x = 
        match x with
        | Ok y    -> Ok <| f y
        | Error e -> Error e

    /// <summary>
    /// Helper function for composing functions with Fish operator with Result values (Railway Oriented Programming)
    /// </summary>
    /// <param name="f">function with one input parameter 'a returning 'b</param>
    /// <param name="x">input parameter 'a</param>
    /// <returns>Result&lt;'b&gt;</returns>
    let switch f x = f x |> Ok 

    let exceptionToResult func =
        try
            Ok(func ()) 
        with
        | :? System.Exception as e -> Error(e)
        | _ as e                   -> Error(System.Exception(e.ToString()))

    module Asnyc =

        /// <summary>
        /// Fish operator (Kleisli Category) for composing functions returning Result values (Railway Oriented Programming).
        /// Asynchronous version
        /// </summary>
        /// <param name="f1">function with one input parameter 'a returning a Result&lt;'b&gt;</param>
        /// <param name="f2">function with one input parameter 'b returning a Result&lt;'c&gt;</param>
        /// <param name="x">input parameter 'a</param>
        /// <returns>function with one input parameter 'a returning a Result&lt;'c&gt;</returns>
        let (>=>) f1 f2 x = async {
            match! f1 x with
            | Ok s    -> return! f2 s
            | Error e -> return Error e
        }

        /// <summary>
        /// Maps the Ok value by  calling function f, leaving the Err value
        /// Asynchronous version
        /// <param name="f">function with one input parameter 'a returning 'b</param>
        /// <param name="x">input parameter Result&lt;'a&gt;</param>
        /// <returns>Result&lt;'b&gt;</returns>
        let map f x = async {
            match! x with
            | Ok y ->
                let! s = f y
                return Ok s
            | Error e -> return Error e
        }