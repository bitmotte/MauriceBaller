firstattempt=true
userpath=""

prompt_path() {
    echo ""
    read userpath
    if [ -d "$userpath/core" ]; then
        echo "found ! ! !"
    else
        echo "invalid path! ! !"
        if [ "$firstattempt" = true ]; then
            echo ""
            echo "tip: make sure that you input the ROOT"
            echo "bepinex path, NOT the plugins folder."
            echo "for example: steampath/ULTRAKILL/BepInEx"
            echo "or r2modmanpath/ULTRAKILL/profiles/Default/BepInEx/"
            firstattempt=false
        fi
        echo ""
        prompt_path
    fi
}

if [ -a "./resources/buildsettings" ]; then
    echo "settings found"
else
    echo "no settings found ! ! ! must make them"
    echo "setting 1: type the path for your bepinex folder:"
    prompt_path
    echo "making settings file. . ."
    touch "./resources/buildsettings"
    printf "$userpath" >> "./resources/buildsettings"
fi

echo ""
echo "building. . ."
dotnet build "MauriceBaller.sln"

userpath=$(< "./resources/buildsettings" )
if [ -d "${userpath}plugins/MauriceBaller/" ]; then
    echo "destroying existing files"
    rm -r -f "${userpath}plugins/MauriceBaller/"
fi

echo "copying build to ultrakill folders"
mkdir "${userpath}plugins/MauriceBaller/"
cp "./bin/Debug/netstandard2.1/bitmotte.MauriceBaller.dll" "${userpath}plugins/MauriceBaller/"
cp "./resources/icon.png" "${userpath}plugins/MauriceBaller/"
echo "done! ! !"
