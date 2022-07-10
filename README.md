# Dynamic-Wallpaper
Get a new desktop background every time you start your computer.

## How to Setup
- Download the executable from the release section in a folder of choice.
- Create a new file called config.ini and open it.
- Type the following

```
DOWNLOAD_LOCATION <image_download_location>
QUERIES { <query>, <query> }
```
- Set the image download location and queries for images as per your choice
- Sample result looks like this
```
DOWNLOAD_LOCATION "G:/My Photos/PC wallpapers/Dynamic Wallpaper/"
QUERIES {"Nature", "Ocean", "Landscape", "Monsoon", "Night", "Mountains"}
```
- Create a shortcut of the executable and copy it to the startup folders of windows programs.
- Setup is complete, restart the PC to check if everything is working.

## Basic Working
  When the app runs it selects a random query from the list provided by user. The it requests an image API for a corresponding image. It uses the WindowsAPI to set it
  as the wallpaper using Snap scaling.
  
## Additional
  If you are not comfortable with having it run on startup, you can pin the app to start menu and run it manually when you want a new wallpaper.
