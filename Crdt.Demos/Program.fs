﻿// Learn more about F# at http://fsharp.org

open System
open Crdt.Demos

[<EntryPoint>]
let main argv =
    CommutativeBwRga.main() |> Async.RunSynchronously
    0 // return an integer exit code
