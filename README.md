# DriveConnect
 HOW TO USE THE APP

1. Open the project
2. Open the file DriveConnect/Helpers/Settings.cs
3. Replace "YOUR APP ID" by your app id

The application is ready to use

HOW TO REPRODUCE THE POSSIBLE LEAK
A. Find data related to the issue reported
1. Open the path of the application : 'SystemAppPath' => C:\Users\--USER NAME--\AppData\Local\Packages\0614a212-e66b-484d-b95d-ecc9ad029c4e_se31rmdjfzbp6
2. Replace --USER NAME-- by the name of the user session
3. Save the path of the file SystemAppPath\LocalState\DriveIntemsInfo.txt (Replace 'SystemAppPath' by his real value, confer 1)

B. Connect to an account
1. Launch the application
2. Sign with your personal or professional account


C. Save the reference of the file
1. Once sign in, choice the type 'My drive' or 'Company Drive'. In case you made the second choice, choice a sharepoint's group or a site
2. Activate the multiple selection switch
3. Select one or multiple files
4. Confirm the selection

At this point the file SystemAppPath\LocalState\DriveIntemsInfo.txt will be created
The file will contains some information of the driveitem. The information are related to those specified in DriveConnect/OneDriveClass/DriveItemInfo.cs

D. Evaluate to the possible data leak
1. Open the file SystemAppPath\LocalState\DriveIntemsInfo.txt
2. Find the downloadurl of one of the file selected
3. Open a web browser in private mode
4. Copy paste the link
5. The file can be downloaded.

WHY WE THINK IS A DATA LEAK
- From our point of view, as soon as a pirate get the download url of any type of file, the file can be downloaded and used.
- For expert, the download url can be retreave by malwares, software like wireshark or any similar software when well configured.
- If a company store this data without encryption in database, and the download url is capture by pirate, the data will be used

LIMITATION OF THE DATA LEAK
The moment we found the download url cannot be used anymore is when both of the below conditions are fullfilled
1. The access token of the user session is expired
2. The user connect again using the application

Which could mean that the download url is update in microsoft server. But we are not sure.

PROPOSITION FOR THE DATA LEAK
Associate the access token for a verification of the user before the file can be downloaded.
