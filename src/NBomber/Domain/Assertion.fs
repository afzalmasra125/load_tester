﻿[<CompilationRepresentationAttribute(CompilationRepresentationFlags.ModuleSuffix)>]
module internal NBomber.Domain.Assertion

open NBomber.Contracts
open NBomber.Errors

let cast (assertions: IAssertion seq) = 
    assertions |> Seq.map(fun x -> x :?> Assertion) |> Seq.toArray

let apply (stepsStats: Statistics[]) (assertions: Assertion[]) =    
    assertions
    |> Array.mapi(fun i asrt ->
        let asrtNum = i + 1            
        let stats = stepsStats |> Array.find(fun x -> x.ScenarioName = asrt.ScenarioName && x.StepName = asrt.StepName)
        if asrt.AssertFunc(stats) then
            None
        else
            Some <| AssertionError(asrtNum, asrt, stats))
    |> Array.choose(id)