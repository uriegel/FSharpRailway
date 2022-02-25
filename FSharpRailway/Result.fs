namespace FSharpRailway

module Result =

    /// <summary>
    /// Functional alternative to exception handling.
    /// Instead of exception handling a Result object is used (Railway Oriented Programming).
    /// There is an option of two possible values: Ok&lt;'a&gt; and Err&lt;Exception&gt;
    /// </summary>
    type Result<'a, 'e> = 
        | Ok  of 'a
        | Err of 'e

    /// <summary>
    /// Fish operator (Kleisli Category) for composing functions returning Result values (Railway Oriented Programming).
    /// </summary>
    /// <param name="switch1">function with one input parameter 'a returning a Result&lt;'b&gt;</param>
    /// <param name="switch2">function with one input parameter 'b returning a Result&lt;'c&gt;</param>
    /// <param name="x">input parameter 'a</param>
    /// <returns>function with one input parameter 'a returning a Result&lt;'c&gt;</returns>
    let (>=>!) switch1 switch2 x =
        match switch1 x with
        | Ok s -> switch2 s
        | Err e   -> Err e

    /// <summary>
    /// Helper function for composing functions with Fish operator with Result values (Railway Oriented Programming)
    /// </summary>
    /// <param name="f">function with one input parameter 'a returning 'b</param>
    /// <param name="x">input parameter 'a</param>
    /// <returns>Result&lt;'b&gt;</returns>
    let switch f x = f x |> Ok 

    let exceptionToResponse func =
        try
            Ok(func ()) 
        with
        | :? System.Exception as e -> Err(e)
        | _ as e -> Err(System.Exception(e.ToString()))