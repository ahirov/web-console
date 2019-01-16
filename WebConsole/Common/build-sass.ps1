$input     = "Styles/web-console.scss"
$output    = "Styles/_output/web-console.css"
$outputMin = "Styles/_output/web-console.min.css"

sass $input $outputMin --no-source-map --style compressed
sass $input $output    --embed-sources --style expanded --watch