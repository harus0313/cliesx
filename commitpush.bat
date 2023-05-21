set /P msg="Input commit message. "

git add --all
git commit -m "%msg%"
git push