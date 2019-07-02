<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>WeatherApp</title>

</head>
<body>

    <form id="form1" runat="server">             

   <asp:TextBox ID="txt1City" runat="server" placeholder="Enter City" />
   <asp:Button Text="Get Weather Info" ID ="Btn" runat="server" OnClick="GetWeatherInfo"  />


   <asp:RequiredFieldValidator id="valid2" runat="server" controltovalidate="txt1City" errormessage="Please enter a city!" /> 
   <asp:RegularExpressionValidator ID ="vlaid1" runat="server" ControlToValidate="txt1City" ErrorMessage ="You must enter a city name!" ValidationExpression="^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$" />  
   <table style="border:3px solid black;"  id="tableWeather" runat="server" visible="false">

       <tr>
           <td>
          <asp:Image ID ="imgWeatherIcon" runat="server" />
           </td>
       </tr>

  <tr>
      <td>
    <asp:Label ID="lblCity_Country" runat="server" />
    <asp:Label ID="lblDescription" runat="server" />


      </td>
  </tr>
  <tr>
      <td>
          Temparature:
    <asp:Label ID="lblTemp" runat="server" />
      </td>
  </tr>
  <tr>
      <td>
          Winddirection:
    <asp:Label ID="lblWinddirection" runat="server" />
      </td>
  </tr>
  <tr>
      <td>
          WindSpeed:
    <asp:Label ID="lblWindspeed" runat="server" />
      </td>
  </tr>
  <tr>
      <td>
          Pressure:
    <asp:Label ID="lblPressure" runat="server" />
      </td>
  </tr>
  <tr>
      <td>
          Average Temparature:
    <asp:Label ID="lblAvgTemp" runat="server" />
      </td>
  </tr>
</table>
 
  </form>

       
</body>
  
</html>