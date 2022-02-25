namespace FSharpRailway

module Option =
    /// <summary>
    /// Fish operator (Kleisli Category) for composing functions returning Option values (Railway Oriented Programming).
    /// </summary>
    /// <param name="switch1">function with one input parameter 'a returning an option&lt;'b&gt;</param>
    /// <param name="switch2">function with one input parameter 'b returning an option&lt;'c&gt;</param>
    /// <param name="x">input parameter 'a</param>
    /// <returns>function with one input parameter 'a returning an option&lt;'c&gt;</returns>
    let (>=>) switch1 switch2 x =
        match switch1 x with
        | Some s -> switch2 s
        | None   -> None

    /// <summary>
    /// Helper function for composing functions with Fish operator with option (Railway Oriented Programming)
    /// </summary>
    /// <param name="f">function with one input parameter 'a returning 'b</param>
    /// <param name="x">input parameter 'a</param>
    /// <returns>option&lt;'b&gt;</returns>
    let switch f x = f x |> Some         

    let OptionFrom2Options a b = 
        match a, b with
        | Some a, Some b -> Some (a, b)
        | _              -> None

    let withInputVar switch x = 
        match switch x with
        | Some s -> Some(x, s)
        | None   -> None

    let omitInputVar (_, b)  = Some(b)

    let exceptionToOption func =
        try
            match func () with
            | res when res <> null -> Some(res) 
            | _                    -> None
        with
        | _ -> None