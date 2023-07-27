<h2>Purpose</h2>
 <p>This sample code converts the /me/categories call from Sitecore OrderCloud into a TAB file as per the specficiations given at https://doc.sitecore.com/discover/en/developers/discover-developer-guide/category-data-feed-specifications.html</p>
 
 <p>The TAB file can then be used to send data to Sitecore Discover for initial bulk upload.</p>
 
 <p>The JSON file is generated from the Sitecore's PLAY! Shop demo instance by calling /me/categories API call. The response of the call is stored in the JSON file.</p>
 
 
 <p>The code is provided as-is without any warranty. This is a starting point, you will have to adjust the code and data models as per the  JSON output/response for your own shop.</p>
 <h2>How to Use</h2>
 <ol>
   <li>Clone the repository locally</li>
   <li>Open the project in VS 2022 and build solution</li>
   <li>Look for the generated file in the bin/debug/data folder, make sure no code or build issues</li>
   <li>Update the data/product_data.json to match your marketplace JSON by calling /me/categories via Sitecore OrderCloud developer console</li>
   <li>Re-run the code</li>
   <li>Upload the file to Sitecore Discover</li>
 </ol>
 <h2>Contribute</h2>
 <p>If you have any suggestions or ideas, open a PR request.</p>