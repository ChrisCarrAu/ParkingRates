# ParkingRates
Calculate Parking Rates - just a bit of fun from a programming test

A rate calculation engine for a carpark, the inputs for this engine are:

<li>Patron’s Entry Date and Time
<li>Patron’s Exit Date and Time
<li>Based on these 2 inputs the engine program should calculate the correct rate for the patron and display the name of the rate along with the total price to the patron using the following rates:

<h1>Early Bird</h1>
<ul>
<li>Flat Rate
<li>$13.0
<li>Entry condition : Enter between 6:00 AM to 9:00 AM
<li>Exit condition : Exit between 3:30 PM to 11:30 PM
</ul>
<h1>Night Rate</h1>
<ul>
<li>Flat Rate
<li>$6.50
<li>Entry condition : Enter between 6:00 PM to midnight (weekdays)
<li>Exit condition : Exit before 6 AM the following day
</ul>
<h1>Weekend Rate</h1>
<ul>
<li>Flat Rate
<li>$10.00
<li>Entry condition : Enter anytime past midnight on Friday to Sunday
<li>Exit condition : any time before midnight of Sunday
</ul>
Note: If a patron enters the carpark before midnight on Friday and if they qualify for Night rate on a Saturday morning, then the program should charge the night rate instead of weekend rate.
<h1>Standard Rate</h1>
<div style="overflow-x:auto;">
  <table>
    <tr><td>Type</td><td>Hourly Rate</td></tr>
    <tr><td>0 - 1</td><td>$5.00</td></tr>
    <tr><td>1 - 2</td><td>$10.00</td></tr>
    <tr><td>2 - 3</td><td>$15.00</td></tr>
    <tr><td>3+</td><td>$20.00 * flat rate per day for each day of parking.</td></tr>
  </table>
</div>
