npm install -g @angular/cli
cd .\city-west-water-ui
npm install
npm build
Start-Process "chrome.exe" "http://localhost:4200"
npm start
Read-Host -Prompt "Press Enter to exit"