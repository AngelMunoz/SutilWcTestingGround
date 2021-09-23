module Pages.Home

open Sutil
open Components.Counter

let Home () =
  Html.article [
    Html.h1 "Home Page"
    Html.section [
      Html.h3 "Counter Starts at 0"
      Html.custom ("su-counter", [ Attr.custom ("init", "0") ])
    ]
    Html.section [
      Html.h3 "Counter Starts at 100"
      Html.custom ("su-counter", [ Attr.custom ("init", "100") ])
    ]
  ]
