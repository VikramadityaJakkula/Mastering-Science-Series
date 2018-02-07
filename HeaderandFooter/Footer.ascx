<%@ Control Language="vb" AutoEventWireup="false" CodeFile="Footer.ascx.vb" Inherits="Footer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<link href="../Styles.css" rel="stylesheet" type="text/css" />

<div id="divUSA" runat="server" visible="true">
	<table class="styleTableFooterBar" width="100%">
		<tr>
			<td class="styleTDFooterPrice" style="HEIGHT: 82px; TEXT-ALIGN: center">
				<a href="http://www.quizmine.com/Purchase.aspx"><strong>$ <%=System.Configuration.ConfigurationManager.AppSettings("BasicPaidModeUSD")%> per year</strong></a>&nbsp;
				<br />
				<br>
				(<strong>Basic Paid Mode</strong>)
				<br>
				<br>
				Quizzes and tutorials for 1 Exam&nbsp; &nbsp;
			</td>
			<td class="styleTDFooterPrice" style="HEIGHT: 82px; TEXT-ALIGN: center">
				<a href="http://www.quizmine.com/Purchase.aspx"><strong>$ <%=System.Configuration.ConfigurationManager.AppSettings("PremiumPaidModeUSD")%> per year</strong></a>&nbsp;
				<br>
				<br>
				(<strong>Premium Paid Mode</strong>)
				<br>
				<br>
				Basic paid mode + Video + Animation (For 1 exam)</td>
			<td class="styleTDFooterPrice" style="HEIGHT: 82px; TEXT-ALIGN: center">
				&nbsp; &nbsp;<a href="http://www.quizmine.com/Purchase.aspx" class="style4"><strong>$ <%=System.Configuration.ConfigurationManager.AppSettings("LifeTimePaidModeUSD")%> LifeTime </strong></a>
				<br>
				<br>
				(<strong>LifeTime Mode</strong>)&nbsp;
				<br>
				<br>
				All Exams + LifeTime of Access</td>
		</tr>
		<tr>
			<td class="styleTDFooterPrice" style="TEXT-ALIGN: center">
				Email: <a href="mailto:quizminegroup@quizmine.com?subject=Need more information" class="style4">
					Quizminegroup@quizmine.com</a>
			</td>
			<td class="styleTDFooterPrice" style="TEXT-ALIGN: center">
				Call: (425) 556 9604 in USA
			</td>
			<td class="styleTDFooterPrice" style="TEXT-ALIGN: center">
				&nbsp;</td>
		</tr>
	</table>
	<table class="styleTableFooterBar" width="100%">
		<tr>
			<td class="styleTableFooterBarTD">

<a class="styleTableFooterbarAlink" href="http://www.quizmine.com/feedback.aspx">Feedback</a>&nbsp; 
                |&nbsp;

				<a class="styleTableFooterbarAlink" href="http://www.quizmine.com/Terms.aspx">Legal</a>&nbsp;&nbsp; 
                |&nbsp;
				<a class="styleTableFooterbarAlink" href="http://www.quizmine.com/PointSystem.aspx">Help</a>&nbsp; 
				|&nbsp; <a class="styleTableFooterbarAlink" id="anchUserStatus" href="http://www.quizmine.com/Registration.aspx" name="anchUserStatus"
					runat="server">Register</a>&nbsp; |&nbsp; <a class="styleTableFooterbarAlink" href="http://www.quizmine.com/sitemap.aspx">
					Site Map</a> | <a class="styleTableFooterbarAlink" href="mailto:quizminegroup@quizmine.com?subject=Need more information">
					Contact Us</a>
			</td>
		</tr>
	</table>
	<hr>
	<table width="100%">
		<tr>
			<td style="WIDTH: 81%">
				<table>
					<tr>
						<td class="region_clr_footerRight" style="WIDTH: 168px">
							Select Your Region:&nbsp;&nbsp;
						</td>
						<td class="region_clr_footer">
							<img src="Images/usaFlag.gif"  border="0" width="37" height="16">&nbsp;</td>
						<td class="region_clr_footerLeft" style="WIDTH: 186px"><strong>United States (Selected)</strong></td>
						<td class="region_clr_footer">&nbsp;|&nbsp;</td> <!--
		<td class="region_clr_footer" >
		<img src="flags/uk_small_flag.gif"  border="0">&nbsp;</td>
		<td class="region_clr_footer" style="width: 104px" >
		<a target="_top" class="region_clr" href="default.aspx?ExamRegion=UK">United Kingdom</a></td>
		<td class="region_clr_footer" style="width: 10px" >&nbsp;|&nbsp;</td>
		<td class="region_clr_footer" >
		<img src="Flags/india_flag.gif"  border="0" width="43" height="21">&nbsp;</td>-->
						<td class="region_clr_footer">
							<a class="region_clr" href="http://www.quizmine.com/india.aspx?UserCountry=India">India (for IIT, IIM)</a></td>
					</tr>
				</table>
			</td>
						<td class="region_clr_footer">&nbsp;|&nbsp;</td> 
						<td class="region_clr_footer">
							<a class="region_clr" href="http://www.quizmine.com/UK.aspx?UserCountry=UK">
							UK&nbsp; (for KS2 and KS3)</a></td>
		</tr>
	</table>
	<table width="100%">
		<tr>
			<td>
				<p id="copyright0" class="region_clr_footer" align="center">Copyright 2009 Quizmine.com, All rights reserved.</p>
			</td>
		</tr>
		
		<tr>
			<td align="center" class="styleTableFooterMkt">
			<br>
			
			<span style="font-size: x-small"><a href="http://www.quizmine.com/ceo.aspx">
			<span style="color: #FF0000">Email to CEO (Return response 
			guranteed)</span></a> | </span>
			<a style="FONT-SIZE: 10pt; COLOR: #000080; FONT-FAMILY: Verdana, Geneva, Arial, Helvetica, sans-serif; TEXT-ALIGN: left; TEXT-DECORATION: underline;" href="http://www.quizmine.com/default.aspx#Animation_anchor"><strong>Super Cool Animation</strong></a>&nbsp; |
			<a href="http://www.quizmine.com/coolvideo.aspx" style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #000080; FONT-FAMILY: Verdana, Geneva, Arial, Helvetica, sans-serif; TEXT-ALIGN: left; TEXT-DECORATION: underline;">
			<strong>
			Super Cool Videos</strong></a> |
				<strong><a href="http://www.quizmine.com/teacher/">Teacher Login</a></strong></td>
		</tr>
		
		<tr>
			<td align="center" class="styleTableFooterMkt">
			** <span style="font-size: x-small">
			<a target="_blank" href="http://www.quizmine.com/jobsandintern.aspx">
			Jobs and Internships</a>**</span></td>
		</tr>
	</table>
</div>
<div id="divIndia" runat="server" visible="true" width="100%">
	<table class="styleTableFooterBar" width="100%">
		<tr>
			<td class="styleTableFooterBarTD"><a class="styleTableFooterbarAlink" href="http://www.quizmine.com/feedback.aspx">Feedback</a>&nbsp; 
                |&nbsp;
				<a class="styleTableFooterbarAlink" href="http://www.quizmine.com/Terms.aspx">Legal</a>&nbsp; 
                |&nbsp;
				<a class="styleTableFooterbarAlink" href="http://www.quizmine.com/PointSystem.aspx">Help</a>&nbsp; 
				|&nbsp; <a class="styleTableFooterbarAlink" id="A2" href="http://www.quizmine.com/Registration.aspx" name="anchUserStatus"
					runat="server">Register</A>&nbsp; |&nbsp; <a class="styleTableFooterbarAlink" href="http://www.quizmine.com/sitemap.aspx">
					Site Map</a> | <a class="styleTableFooterbarAlink" href="mailto:quizminegroup@quizmine.com?subject=Need more information">
					Contact Us</a>
			</td>
		</tr>
	</table>
	<table class="styleTableFooterBar" width="100%">
		<tr>
			<td class="styleTDFooterPrice" style="HEIGHT: 82px; TEXT-ALIGN: center">
				<a href="http://www.quizmine.com/Purchase.aspx"><strong>Rs <%=System.Configuration.ConfigurationManager.AppSettings("BasicPaidModeINR")%> per year</strong></a>&nbsp;
				<br>
				<br>
				(<strong>Basic Paid Mode</strong>)
				<br>
				<br>
				Online quizzes, tutorials
				<br>
				&amp; progress report for 1 Exam&nbsp;&nbsp;
			</td>
			<td class="styleTDFooterPrice" style="HEIGHT: 82px; TEXT-ALIGN: center">
				<a href="http://www.quizmine.com/Purchase.aspx"><strong>Rs <%=System.Configuration.ConfigurationManager.AppSettings("PremiumPaidModeINR")%> per year</strong></a>&nbsp;
				<br>
				<br>
				(<strong>Premium Paid Mode</strong>)
				<br>
				<br>
				Basic paid mode + Video + Animation (For 1 exam)&nbsp;
			</td>
			<td class="styleTDFooterPrice" style="HEIGHT: 82px; TEXT-ALIGN: center">
				&nbsp; &nbsp;<a href="http://www.quizmine.com/Purchase.aspx" class="style4"><strong>Rs <%=System.Configuration.ConfigurationManager.AppSettings("LifeTimePaidModeINR")%> LifeTime </strong></a>
				<br>
				<br>
				(<strong>LifeTime Paid Mode</strong>)&nbsp;
				<br>
				<br>
				All Exams + LifeTime of Access &nbsp;&nbsp;</td>
		<tr>
			<td class="styleTDFooterPrice" style="TEXT-ALIGN: center">
				Email: <a href="mailto:quizminegroup@quizmine.com?subject=Need more information" class="style4">
					Quizminegroup@quizmine.com</a>
			</td>
			<td class="styleTDFooterPrice" style="TEXT-ALIGN: center">
				Call: (425) 556 9604 in USA
			</td>
			<td class="styleTDFooterPrice" style="TEXT-ALIGN: center">
				&nbsp;</td>
		</tr>
	</table>
	<table width="100%">
		<tr>
			<td></td>
			<td class="styleTDFooterPriceMarket ">
				&nbsp;</td>
			<td></td>
		</tr>
	</table>
	<hr>
	<table width="100%">
		<tr>
			<td style="WIDTH: 81%">
				<table>
					<tr>
						<td class="region_clr_footerRight" style="WIDTH: 168px">
							Select Your Region:&nbsp;&nbsp;
						</td>
						<td class="region_clr_footer">
							<img src="Images/indiaFlag.gif"  border="0" width="29" height="14">&nbsp;</td>
						<td class="region_clr_footerLeft" style="WIDTH: 186px"><strong>India (Selected)</strong></td>
						<td class="region_clr_footer">&nbsp;|&nbsp;</td> <!--
		<td class="region_clr_footer" >
		<img src="flags/uk_small_flag.gif"  border="0">&nbsp;</td>
		<td class="region_clr_footer" style="width: 104px" >
		<a class="region_clr" href="default.aspx?ExamRegion=UK">United Kingdom</a></td>
		<td class="region_clr_footer" style="width: 10px" >&nbsp;|&nbsp;</td>
		<td class="region_clr_footer" >
		<img src="Flags/india_flag.gif"  border="0" width="43" height="21">&nbsp;</td>-->
						<td class="region_clr_footer">
							<a class="region_clr" href="http://www.quizmine.com/default.aspx?UserCountry=USA">United States</a></td>
					</tr>
				</table>
			</td>
						<td class="region_clr_footer">&nbsp;|&nbsp;</td> 
						<td class="region_clr_footer">
							<a class="region_clr" href="http://www.quizmine.com/UK.aspx?UserCountry=UK">UK&nbsp; (for KS2 and KS3)</a></td>
		</tr>
	</table>
	<table width="100%">
		<tr>
			<td>
				<p id="copyright" class="region_clr_footer" align="center">Copyright 2009 Quizmine.com, All rights reserved.</p>
			</td>
		</tr>
		<tr>
			<td align="center" class="styleTableFooterMkt">
			<table>
			<tr>
			<td  valign="top">
			<br />
			<span style="font-size: x-small"><a href="http://www.quizmine.com/ceo.aspx">
			<span style="color: #FF0000">Email to CEO (Return response 
			guranteed)</span></a></span> |
			<a style="FONT-SIZE: 10pt; COLOR: #000080; FONT-FAMILY: Verdana, Geneva, Arial, Helvetica, sans-serif; TEXT-ALIGN: left; TEXT-DECORATION: underline;" href="http://www.quizmine.com/default.aspx#Animation_anchor"><strong>Super Cool Animation</strong></a>&nbsp; |
			<a href="http://www.quizmine.com/coolvideo.aspx" style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #000080; FONT-FAMILY: Verdana, Geneva, Arial, Helvetica, sans-serif; TEXT-ALIGN: left; TEXT-DECORATION: underline;">
			<strong>
			Super Cool Videos</strong></a> |
				<strong><a href="http://www.quizmine.com/teacher/">Teacher Login</a></strong>
			</td>
		</tr>
		<tr>
			<td align="center" class="styleTableFooterMkt">
			** <span style="font-size: x-small">
			<a target="_blank" href="http://www.quizmine.com/jobsandintern.aspx">
			Jobs and internships </a>**</span></td>
		</tr>
	</table>
</div>
<div id="divUK" runat="server" visible="true">
	<table class="styleTableFooterBar" width="100%">
		<tr>
			<td class="styleTDFooterPrice" style="HEIGHT: 82px; TEXT-ALIGN: center">
				<a href="http://www.quizmine.com/Purchase.aspx"><strong>$ <%=System.Configuration.ConfigurationManager.AppSettings("BasicPaidModeUSD")%> per year</strong></a>&nbsp;
				<br>
				<br>
				(<strong>Basic Paid Mode</strong>)
				<br>
				<br>
				Quizzes and tutorials for 1 Exam&nbsp; &nbsp;
			</td>
			<td class="styleTDFooterPrice" style="HEIGHT: 82px; TEXT-ALIGN: center">
				<a href="http://www.quizmine.com/Purchase.aspx"><strong>$ <%=System.Configuration.ConfigurationManager.AppSettings("PremiumPaidModeUSD")%> per year</strong></a>&nbsp;
				<br>
				<br>
				(<strong>Premium Paid Mode</strong>)
				<br>
				<br>
				Basic paid mode + Video + Animation (For 1 exam)</td>
			<td class="styleTDFooterPrice" style="HEIGHT: 82px; TEXT-ALIGN: center">
				&nbsp; &nbsp;<a href="http://www.quizmine.com/Purchase.aspx" class="style4"><strong>$ <%=System.Configuration.ConfigurationManager.AppSettings("LifeTimePaidModeUSD")%> LifeTime </strong></a>
				<br>
				<br>
				(<strong>LifeTime Mode</strong>)&nbsp;
				<br>
				<br>
				All Exams + LifeTime of Access</td>
		</tr>
		<tr>
			<td class="styleTDFooterPrice" style="TEXT-ALIGN: center">
				Email: <a href="mailto:quizminegroup@quizmine.com?subject=Need more information" class="style4">
					Quizminegroup@quizmine.com</a>
			</td>
			<td class="styleTDFooterPrice" style="TEXT-ALIGN: center">
				Call: (425) 556 9604 in USA
			</td>
			<td class="styleTDFooterPrice" style="TEXT-ALIGN: center">
				&nbsp;</td>
		</tr>
	</table>
	<table class="styleTableFooterBar" width="100%">
		<tr>
			<td class="styleTableFooterBarTD">
			<a class="styleTableFooterbarAlink" href="http://www.quizmine.com/feedback.aspx">Feedback</a>&nbsp; 
                |&nbsp;
				<a class="styleTableFooterbarAlink" href="http://www.quizmine.com/Terms.aspx">Legal</a>&nbsp; 
                |&nbsp;&nbsp;
				<a class="styleTableFooterbarAlink" href="http://www.quizmine.com/PointSystem.aspx">Help</a>&nbsp; 
				|&nbsp; <a class="styleTableFooterbarAlink" id="anchUserStatus1" href="http://www.quizmine.com/Registration.aspx" name="anchUserStatus"
					runat="server">Register</a>&nbsp; |&nbsp; <a class="styleTableFooterbarAlink" href="http://www.quizmine.com/sitemap.aspx">
					Site Map</a> | <a class="styleTableFooterbarAlink" href="mailto:quizminegroup@quizmine.com?subject=Need more information">
					Contact Us</a>
			</td>
		</tr>
	</table>
	<hr>
	<table width="100%">
		<tr>
			<td style="WIDTH: 81%">
				<table>
					<tr>
						<td class="region_clr_footerRight" style="WIDTH: 168px">
							Select Your Region:&nbsp;&nbsp;
						</td>
						<td class="region_clr_footer">
									<IMG src="Images/ukFlag.jpg"  border="0" width="37" height="21" style="float: left"></td>
						<td class="region_clr_footerLeft" style="WIDTH: 186px"><strong>United 
						Kingdom (Selected)</strong></td>
						<td class="region_clr_footer">&nbsp;|&nbsp;</td> <!--
		<td class="region_clr_footer" >
		<img src="flags/uk_small_flag.gif"  border="0">&nbsp;</td>
		<td class="region_clr_footer" style="width: 104px" >
		<a target="_top" class="region_clr" href="default.aspx?ExamRegion=UK">United Kingdom</a></td>
		<td class="region_clr_footer" style="width: 10px" >&nbsp;|&nbsp;</td>
		<td class="region_clr_footer" >
		<img src="Flags/india_flag.gif"  border="0" width="43" height="21">&nbsp;</td>-->
						<td class="region_clr_footer">
							<a class="region_clr" href="http://www.quizmine.com/india.aspx?UserCountry=India">India (for IIT, IIM)</a></td>
					</tr>
				</table>
			</td>
						<td class="region_clr_footer">&nbsp;|&nbsp;</td> 
						<td class="region_clr_footer">
							<a class="region_clr" href="http://www.quizmine.com/default.aspx?UserCountry=USA">United States</a></td>
		</tr>
	</table>
	<table width="100%">
		<tr>
			<td>
				<p id="copyright0" class="region_clr_footer" align="center">Copyright 2009 Quizmine.com, All rights reserved.</p>
			</td>
		</tr>
		
		<tr>
			<td align="center" class="styleTableFooterMkt">
			<br>
			
			<span style="font-size: x-small"><a href="http://www.quizmine.com/ceo.aspx">
			<span style="color: #FF0000">Email to CEO (Return response 
			guranteed)</span></a> | </span>
			<a style="FONT-SIZE: 10pt; COLOR: #000080; FONT-FAMILY: Verdana, Geneva, Arial, Helvetica, sans-serif; TEXT-ALIGN: left; TEXT-DECORATION: underline;" href="http://www.quizmine.com/default.aspx#Animation_anchor"><strong>Super Cool Animation</strong></a>&nbsp; |
			<a href="http://www.quizmine.com/coolvideo.aspx" style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #000080; FONT-FAMILY: Verdana, Geneva, Arial, Helvetica, sans-serif; TEXT-ALIGN: left; TEXT-DECORATION: underline;">
			<strong>
			Super Cool Videos</strong></a> |
				<strong><a href="http://www.quizmine.com/teacher/">Teacher Login</a></strong></td>
		</tr>
		
		<tr>
			<td align="center" class="styleTableFooterMkt">
			** <span style="font-size: x-small">
			<a target="_blank" href="http://www.quizmine.com/jobsandintern.aspx">
			Jobs and internships </a>**</span></td>
		</tr>
	</table>
</div>


<script src="http://www.google-analytics.com/urchin.js" type="text/javascript">
</script>
<script type="text/javascript">
	_uacct = "UA-280293-1";
	urchinTracker();
</script>
