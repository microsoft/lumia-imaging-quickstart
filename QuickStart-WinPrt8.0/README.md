Quick Start
===============

Quick Start application demonstrates how to create a simple imaging application
using the Nokia Imaging SDK.  It shows how to apply a filter effect to an 
image and save it to file.

The example has been developed with Silverlight for Windows Phone devices
and tested to work on Nokia Lumia devices with Windows Phone 8.


For more information on implementation, visit Nokia Lumia
Developer's Library:
http://developer.nokia.com/resources/library/Lumia/nokia-imaging-sdk/quick-start.html


1. Usage
-------------------------------------------------------------------------------

This is a simple build-and-run solution. See section 5 for instructions on how
to run the application on your Windows Phone 8 device.


2. Prerequisites
-------------------------------------------------------------------------------

* C# basics
* Windows 8
* Development environment Microsoft Visual Studio Express for Windows Phone 2012


3. Project structure and implementation
-------------------------------------------------------------------------------

3.1 Folders
-----------

* The root folder contains the project file, the license information and this
  file.
* `QuickStart`: Root folder for the implementation files.  
 * `Assets`: Graphic assets like icons and tiles.
 * `Properties`: Application property files.
 * `Resources`: Application resources.


3.2 Important files and classes
-------------------------------

| File | Description |
| ---- | ----------- |
| `MainPage.xaml.cs` | Main page, displays photo rendered with applied filter. |


4. Compatibility
-------------------------------------------------------------------------------

Application works on Windows Phone 8.

Tested to work on Nokia Lumia 520, Nokia Lumia 620, Nokia Lumia 820 and Nokia
Lumia 920.

Developed with Microsoft Visual Studio Express for Windows Phone 2012.


4.2 Known Issues
----------------

None.


5. Building, installing, and running the application
-------------------------------------------------------------------------------

5.1 Preparations
----------------

Make sure you have the following installed:
 * Windows 8
 * Windows Phone SDK 8.0

5.2 Using the WINDOWS PHONE 8 SDK
---------------------------------

1. Open the SLN file:
   File > Open Project, select the file QuickStart.sln
2. Select the target 'Device' and 'ARM'.
3. Press F5 to build the project and run it on the device.

5.3 Deploying to Windows Phone 8
--------------------------------

Please see official documentation for deploying and testing applications on
Windows Phone devices:
http://msdn.microsoft.com/library/windowsphone/develop/ff402565(v=vs.105).aspx


6. License
-------------------------------------------------------------------------------

See the license text file delivered with this project


7. Version history
-------------------------------------------------------------------------------

* 1.2.0.0: Second public release of Quick Start
  - Updated to match Nokia Imaging SDK 1.2

* 1.1.0.0: Second public release of Quick Start
  - Updated to match Nokia Imaging SDK 1.1
  
* 1.0.0.0: First public release of Quick Start
