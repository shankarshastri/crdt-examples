/// The MIT License (MIT)
/// Copyright (c) 2018 Bartosz Sypytkowski

namespace Crdt.Convergent

open Crdt

type GSet<'a when 'a: comparison> = GSet of Set<'a>

[<RequireQualifiedAccess>]
module GSet =
    let zero: GSet<'a> = GSet Set.empty
    let value (GSet(s)) = s
    let add v (GSet(s)) = GSet (Set.add v s)
    let merge (GSet(a)) (GSet(b)) = GSet (a + b)

    [<Struct>]
    type Merge<'a when 'a: comparison> = 
        interface IConvergent<GSet<'a>> with
            member __.merge a b = merge a b 