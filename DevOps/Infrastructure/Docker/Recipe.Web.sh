#!/bin/bash

# Recreate config file
rm -rf ./usr/share/nginx/html/env-config.js
touch ./usr/share/nginx/html/env-config.js

var=$(jq -n '$ENV')
echo "window._env_ = " >> /usr/share/nginx/html/env-config.js
echo $var >> /usr/share/nginx/html/env-config.js