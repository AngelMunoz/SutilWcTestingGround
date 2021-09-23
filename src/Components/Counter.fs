module Components.Counter

open Sutil
open Sutil.DOM
open Sutil.Attr
open Sutil.WebComponents

open ShadowStyles
open ShadowStyles.Operators
open Browser.Types
open Fable.Core.JsInterop

type private ComponentProps = {| init: int |}

let private styles =
  [ "button" => [ SCss.backgroundColor "#FFCC00" ]
    "div" => [ SCss.color "#FF00FF" ] ]

let private Counter (props: Store<ComponentProps>) =
  // ShadowStyles doesn't work because this is not equivalent
  // to the HTMLElement that powers the web component
  // ShadowStyles.adoptStyleSheet (jsThis, styles) // uncommenting this line makes it fail
  let count = props .> (fun p -> p.init)
  let initVal = props |-> (fun props -> props.init)
  let getCount () = props |-> (fun props -> props.init)

  Html.div [
    disposeOnUnmount [ props ]
    Bind.fragment count (fun counter -> Html.text $"{counter}")
    Html.br []
    Html.button [
      onClick
        (fun _ ->
          props
          <~= (fun props -> {| props with init = getCount () + 1 |}))
        []
      Html.text "Increment"
    ]
    Html.button [
      onClick
        (fun _ ->
          props
          <~= (fun props -> {| props with init = getCount () - 1 |}))
        []
      Html.text "Decrement"
    ]
    Html.button [
      onClick
        (fun _ ->
          props
          <~= (fun props -> {| props with init = initVal |}))
        []
      Html.text "Reset"
    ]
  ]

let register () =
  registerWebComponent "su-counter" Counter {| init = 0 |}
