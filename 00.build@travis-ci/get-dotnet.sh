#!/usr/bin/env bash

set -euo pipefail

# variables
DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"
OBJDIR="$DIR/obj"
global_json_path="$DIR/global.json"
dotnet_install_path="$DIR/../../.dotnet"
install_script_url="https://dot.net/v1/dotnet-install.sh"
install_script_path="$OBJDIR/dotnet-install.sh"

# functions
ensure_dir() {
    [ -d $1 ] || mkdir $1
}

# main

# resolve SDK version
sdk_version=$(jq -r .sdk.version $global_json_path)

# download dotnet-install.sh
ensure_dir $OBJDIR

echo "Downloading install script: $install_script_url => $install_script_path"
curl -sSL -o $install_script_path $install_script_url
chmod +x $install_script_path

$install_script_path -v $sdk_version -i $dotnet_install_path