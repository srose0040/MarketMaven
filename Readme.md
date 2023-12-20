<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>

<h1>MarketMaven Stock Market Watcher</h1>

<h2>Purpose</h2>
<p>MarketMaven is a stock market watcher application designed to help users monitor stock prices and track their performance over time.</p>

<h2>Project Structure</h2>

<p>This project is organized into two main branches:</p>

<ul>
  <li><strong>Main Branch (EXTJS Front End):</strong>
    <ul>
      <li>Contains the EXTJS front-end code responsible for the user interface.</li>
      <li>File: <a href="https://github.com/srose0040/MarketMaven/tree/main">ExtJS Front End Code</a></li>
    </ul>
  </li>
  <li><strong>Master Branch (ASP.NET Web API Backend):</strong>
    <ul>
      <li>Contains the ASP.NET Web API backend code responsible for handling stock data.</li>
      <li>File: <a href="https://github.com/srose0040/MarketMaven/tree/master">ASP.NET Web API Backend Code</a></li>
    </ul>
  </li>
</ul>

<h2>Setup and Running the Application</h2>

<p>To set up and run the full application, follow these steps:</p>

<ol>
  <li>Clone the repository:</li>
  <pre><code>git clone [https://github.com/srose0040/MarketMaven.git]</code></pre>

  <li>Switch to the main branch for the EXTJS front end:</li>
  <pre><code>git checkout main</code></pre>

  <li>Install dependencies and run the front-end application.</li>

  <li>Switch to the master branch for the ASP.NET Web API backend:</li>
  <pre><code>git checkout master</code></pre>

  <li>Set up and run the ASP.NET Web API backend.</li>

  <li>Ensure both branches are available to have the complete system running.</li>
</ol>

<h2>EXTJS Front End</h2>

<p>The EXTJS front end consists of several components, including a main grid for displaying stock information and a form for adding new stocks to the watchlist.</p>

<h3>Main Grid</h3>
<pre><code>
Ext.define('MarketMaven.view.main.Grid', {
    // ...
});
</code></pre>

<h3>Form</h3>
<pre><code>
Ext.define('MarketMaven.view.main.Form', {
    // ...
});
</code></pre>

<h2>ASP.NET Web API Backend</h2>

<p>The ASP.NET Web API backend handles stock data, including fetching the latest stock information and storing historical data.</p>

<h3>Stock Controller</h3>
<pre><code>
namespace StockMarketWatcherBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // ...
    }
}
</code></pre>

<h3>Stock Model</h3>
<pre><code>
namespace StockMarketWatcherBackend
{
    public class Stock
    {
        // ...
    }
}
</code></pre>

<p>Feel free to explore each branch for detailed code and functionality. For a seamless experience, ensure both branches are available and correctly set up.</p>

</body>
</html>
