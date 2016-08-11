# Sitecore.Support.120848
An anchor added to the link in RTE may appear in the middle of the querystring instead of being the last.

## Description
When inserting the links as follows in RTE:
```
/~/media/engagement_analytics_configuration_reference_sc70-a4#page=3
```

they might be rendered as follows on the page:
```
/~/media/engagement_analytics_configuration_reference_sc70-a4#page=3?la=en
```

however expected is:
```
/~/media/engagement_analytics_configuration_reference_sc70-a4?la=en#page=3
```

## License  
This patch is licensed under the [Sitecore Corporation A/S License for GitHub](https://github.com/sitecoresupport/Sitecore.Support.120848/blob/master/LICENSE).  

## Download  
Downloads are available via [GitHub Releases](https://github.com/sitecoresupport/Sitecore.Support.120848/releases).  
