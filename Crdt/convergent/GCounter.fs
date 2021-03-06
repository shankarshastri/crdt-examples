/// The MIT License (MIT)
/// Copyright (c) 2018 Bartosz Sypytkowski

namespace Crdt.Convergent

open Crdt

type GCounter = GCounter of Map<ReplicaId, int64>

[<RequireQualifiedAccess>]
module GCounter =

    let zero = GCounter Map.empty

    let value (GCounter(c)) = c |> Map.fold (fun acc _ v -> acc + v) 0L

    let inc replica value (GCounter(c)) =
        Helpers.upsert replica value ((+) value) c |> GCounter

    let merge (GCounter(a)) (GCounter(b)) =
        a 
        |> Map.fold (fun acc k va -> Helpers.upsert k va (max va) acc) b
        |> GCounter
        
    [<Struct>]
    type Merge = 
        interface IConvergent<GCounter> with
            member __.merge a b = merge a b 