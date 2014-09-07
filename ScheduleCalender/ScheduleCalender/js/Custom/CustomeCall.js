
        $(document).ready(function () {

            var clickDate = "";
            var clickAgendaItem = "";

            /**
             * Initializes calendar with current year & month
             * specifies the callbacks for day click & agenda item click events
             * then returns instance of plugin object
             */
            var jfcalplugin = $("#mycal").jFrontierCal({
                date: new Date(),
                dayClickCallback: myDayClickHandler,
                agendaClickCallback: myAgendaClickHandler,
                agendaDropCallback: myAgendaDropHandler,
                agendaMouseoverCallback: myAgendaMouseoverHandler,
                applyAgendaTooltipCallback: myApplyTooltip,
                agendaDragStartCallback: myAgendaDragStart,
                agendaDragStopCallback: myAgendaDragStop,
                dragAndDropEnabled: true
            }).data("plugin");

            //Current Month
            var d = new Date();
            //alert(myFunction(d.getMonth()));
            document.getElementById("monthName").innerHTML = myFunction(d.getMonth());
            //End Current Month
            DisplayCalData();
            /* Display Event */
            function DisplayCalData() {
                jfcalplugin.deleteAllAgendaItems("#mycal");
                $.ajax({
                    contentType: "application/json; charset=utf-8",
                    data: '{}',
                    dataType: "json",
                    type: "POST",
                    url: "MyCalender.aspx/ViewEvents",                                        //the code behind method
                    success: function (data) {                                                  //using the value returned by the code behind in a for loop to print all the existing events from the DB
                        for (var i = 0; i < data.d.length; i++) {
                            var startYear = data.d[i].startYear.toString();
                            var startMonth = data.d[i].startMonth.toString();
                            var startDay = data.d[i].startDay.toString();
                            var startHour = data.d[i].startHour.toString();
                            var startMin = data.d[i].startMin.toString();

                            var endYear = data.d[i].endYear.toString();
                            var endMonth = data.d[i].endMonth.toString();
                            var endDay = data.d[i].endDay.toString();
                            var endHour = data.d[i].endHour.toString();
                            var endMin = data.d[i].endMin.toString();

                            var startDateObj = new Date(parseInt(startYear), parseInt(startMonth) - 1, parseInt(startDay), startHour, startMin, 0, 0);
                            var endDateObj = new Date(parseInt(endYear), parseInt(endMonth) - 1, parseInt(endDay), endHour, endMin, 0, 0);

                            jfcalplugin.addAgendaItem(                  //This is the method that adds the event to the calander. Refer the documentation for more details of this method
                            "#mycal",                                      //The Div element for my calander
                            data.d[i].eventName,
                            startDateObj,
                            endDateObj,
                            false,
                            {

                                // FirstName: data.d[i].firstName.toString(),
                                //LastName: data.d[i].lastName.toString(),
                                //OtherInfo: data.d[i].otherInfo.toString(),
                                //myDate: new Date(),
                                ID: data.d[i].eventID

                            },
                            {
                                backgroundColor: data.d[i].backgroundColor.toString(),
                                foregroundColor: data.d[i].foregroundColor.toString()
                            }
                            );
                        }
                    },
                    error: function (result) {
                        alert(result.responseText);
                    }
                });
            };
            //End Display

            /**
             * Do something when dragging starts on agenda div
             */
            function myAgendaDragStart(eventObj, divElm, agendaItem) {
                // destroy our qtip tooltip
                if (divElm.data("qtip")) {
                    divElm.qtip("destroy");
                }
            };

            /**
             * Do something when dragging stops on agenda div
             */
            function myAgendaDragStop(eventObj, divElm, agendaItem) {
                //alert("drag stop");
            };

            /**
             * Custom tooltip - use any tooltip library you want to display the agenda data.
             * for this example we use qTip - http://craigsworks.com/projects/qtip/
             *
             * @param divElm - jquery object for agenda div element
             * @param agendaItem - javascript object containing agenda data.
             */
            function myApplyTooltip(divElm, agendaItem) {

                // Destroy currrent tooltip if present
                if (divElm.data("qtip")) {
                    divElm.qtip("destroy");
                }

                var displayData = "";

                var title = agendaItem.title;
                var startDate = agendaItem.startDate;

                var startDate = new Date(startDate + " UTC");
                startDate = startDate.toString().replace(/GMT.*/g, "");

                var endDate = agendaItem.endDate;

                var endDate = new Date(endDate + " UTC");
                endDate = endDate.toString().replace(/GMT.*/g, "");

                var allDay = agendaItem.allDay;
                var result = agendaItem.data;
                var eID = agendaItem.data.ID;

                // use the user specified colors from the agenda item.
                var backgroundColor = agendaItem.displayProp.backgroundColor;
                var foregroundColor = agendaItem.displayProp.foregroundColor;
                var myStyle = {
                    border: {
                        width: 5,
                        radius: 10
                    },
                    padding: 10,
                    textAlign: "left",
                    tip: true,
                    name: "dark" // other style properties are inherited from dark theme		
                };
                if (backgroundColor != null && backgroundColor != "") {
                    myStyle["backgroundColor"] = backgroundColor;
                }
                if (foregroundColor != null && foregroundColor != "") {
                    myStyle["color"] = foregroundColor;
                }

                displayData += "<br><b>" + title + "</b><br><br>";
                if (allDay) {
                    displayData += "(All day event)<br><br>";
                } else {
                   displayData += "<b>Starts:</b> " + startDate + "<br>" + "<b>Ends:</b> " + endDate + "<br><br>";
                    //Start Database

                    $.ajax({
                        contentType: "application/json; charset=utf-8",
                        data: "{evid:" + JSON.stringify(eID) + "}",
                        dataType: "json",
                        type: "POST",
                        url: "MyCalender.aspx/ViewToolTips",                                        //the code behind method
                        success: function (data) {                                                  //using the value returned by the code behind in a for loop to print all the existing events from the DB
                            for (var i = 0; i < data.d.length; i++) {
                                for (var propertyName in data.d[i]) {
                                    if (data.d[i][propertyName] != null && propertyName != '__type' && propertyName != 'eventID')                                        
                                        displayData += "<b>" + propertyName + ":</b> " + data.d[i][propertyName] + "<br>"
                                }
                                //displayData += "<b>" + Test + ":</b> " + (data.d[i].otherInfo.toString()) + "<br>"
                                //displayData += "<b>Starts:</b> " + startDate + "<br>" + "<b>Ends:</b> " + endDate + "<br><br>";
                                //alert(displayData);
                                // apply tooltip
                                divElm.qtip({
                                    content: displayData,
                                    position: {
                                        corner: {
                                            tooltip: "bottomMiddle",
                                            target: "topMiddle"
                                        },
                                        adjust: {
                                            mouse: true,
                                            x: 0,
                                            y: -15
                                        },
                                        target: "mouse"
                                    },
                                    show: {
                                        when: {
                                            event: 'mouseover'
                                        }
                                    },
                                    style: myStyle
                                });
                            }
                        },
                        error: function (result) {
                            alert(result.responseText);
                        }
                    });
                    //End Database
                   
                }
             

                //for (var propertyName in data) {
                //    displayData += "<b>" + propertyName + ":</b> " + data[propertyName] + "<br>"
                //}
               
               

            };

            /**
             * Make the day cells roughly 3/4th as tall as they are wide. this makes our calendar wider than it is tall. 
             */
            jfcalplugin.setAspectRatio("#mycal", 0.75);

            /**
             * Called when user clicks day cell
             * use reference to plugin object to add agenda item
             */
            function myDayClickHandler(eventObj) {
                // Get the Date of the day that was clicked from the event object
                var date = eventObj.data.calDayDate;
                // store date in our global js variable for access later
                clickDate = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
                // open our add event dialog
                $('#add-event-form').dialog('open');
            };

            /**
             * Called when user clicks and agenda item
             * use reference to plugin object to edit agenda item
             */
            function myAgendaClickHandler(eventObj) {
                // Get ID of the agenda item from the event object
                var agendaId = eventObj.data.agendaId;
                // pull agenda item from calendar
                var agendaItem = jfcalplugin.getAgendaItemById("#mycal", agendaId);
                clickAgendaItem = agendaItem;
                $("#display-event-form").dialog('open');
            };

            /**
             * Called when user drops an agenda item into a day cell.
             */
            function myAgendaDropHandler(eventObj) {
                // Get ID of the agenda item from the event object
                var agendaId = eventObj.data.agendaId;
                // date agenda item was dropped onto
                var date = eventObj.data.calDayDate;
                var date = new Date(date + " UTC");
                var newDate = date.toString().replace(/GMT.*/g, "");
                // Pull agenda item from calendar
                var agendaItem = jfcalplugin.getAgendaItemById("#mycal", agendaId);
                alert("You dropped agenda item " + agendaItem.title +
                    " onto " + newDate.toString() + ". ");
                var event = new Object();
                event.eventID = agendaItem.data.ID

               
                //alert(date.getDate());
                event.startYear = (date.getFullYear());
                event.startMonth = (date.getMonth())+1;
                event.startDay = (date.getDate());

                //Start Database
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    data: "{eventdata:" + JSON.stringify(event) + "}",
                    url: "MyCalender.aspx/DragEvent",
                    dataType: "json",
                    success: function (data) {
                        DisplayCalData();                       

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        debugger;
                    }
                });
                //End Database
            };

            /**
             * Called when a user mouses over an agenda item	
             */
            function myAgendaMouseoverHandler(eventObj) {
                var agendaId = eventObj.data.agendaId;
                var agendaItem = jfcalplugin.getAgendaItemById("#mycal", agendaId);
                //alert("You moused over agenda item " + agendaItem.title + " at location (X=" + eventObj.pageX + ", Y=" + eventObj.pageY + ")");
            };
            /**
             * Initialize jquery ui datepicker. set date format to yyyy-mm-dd for easy parsing
             */
            $("#dateSelect").datepicker({
                showOtherMonths: true,
                selectOtherMonths: true,
                changeMonth: true,
                changeYear: true,
                showButtonPanel: true,
                dateFormat: 'yy-mm-dd'
            });

            /**
             * Set datepicker to current date
             */
            $("#dateSelect").datepicker('setDate', new Date());
            /**
             * Use reference to plugin object to a specific year/month
             */
            $("#dateSelect").bind('change', function () {
                var selectedDate = $("#dateSelect").val();
                var dtArray = selectedDate.split("-");
                var year = dtArray[0];
                // jquery datepicker months start at 1 (1=January)		
                var month = dtArray[1];                
                // strip any preceeding 0's		
                month = month.replace(/^[0]+/g, "")
                //alert(myFunction(month-1));
                document.getElementById("monthName").innerHTML =(myFunction(month - 1));
                var day = dtArray[2];
                // plugin uses 0-based months so we subtrac 1
                jfcalplugin.showMonth("#mycal", year, parseInt(month - 1).toString());
            });
            /**
             * Initialize previous month button
             */
            $("#BtnPreviousMonth").button();
            $("#BtnPreviousMonth").click(function () {
                jfcalplugin.showPreviousMonth("#mycal");
                // update the jqeury datepicker value
                var calDate = jfcalplugin.getCurrentDate("#mycal"); // returns Date object
                var cyear = calDate.getFullYear();
                // Date month 0-based (0=January)
                var cmonth = calDate.getMonth();
                var cday = calDate.getDate();
                //alert(myFunction(cmonth));
                document.getElementById("monthName").innerHTML = (myFunction(cmonth));
                // jquery datepicker month starts at 1 (1=January) so we add 1
                $("#dateSelect").datepicker("setDate", cyear + "-" + (cmonth + 1) + "-" + cday);
                return false;
            });
            /**
             * Initialize next month button
             */
            $("#BtnNextMonth").button();
            $("#BtnNextMonth").click(function () {
                jfcalplugin.showNextMonth("#mycal");
                // update the jqeury datepicker value
                var calDate = jfcalplugin.getCurrentDate("#mycal"); // returns Date object
                var cyear = calDate.getFullYear();
                // Date month 0-based (0=January)
                var cmonth = calDate.getMonth();
                var cday = calDate.getDate();
                //alert(myFunction(cmonth));
                document.getElementById("monthName").innerHTML = (myFunction(cmonth));
                // jquery datepicker month starts at 1 (1=January) so we add 1
                $("#dateSelect").datepicker("setDate", cyear + "-" + (cmonth + 1) + "-" + cday);
                return false;
            });

            /**
             * Initialize delete all agenda items button
             */
            $("#BtnDeleteAll").button();
            $("#BtnDeleteAll").click(function () {
                jfcalplugin.deleteAllAgendaItems("#mycal");
                return false;
            });

            /**
             * Initialize iCal test button
             */
            //$("#BtnICalTest").button();
            //$("#BtnICalTest").click(function () {
            //    // Please note that in Google Chrome this will not work with a local file. Chrome prevents AJAX calls
            //    // from reading local files on disk.		
            //    jfcalplugin.loadICalSource("#mycal", $("#iCalSource").val(), "html");
            //    return false;
            //});

            /**
             * Initialize add event modal form
             */
            ////$("#add-event-form").dialog({
            ////    autoOpen: false,
            ////    height: 450,
            ////    width: 400,
            ////    modal: true,
            ////    buttons: {
            ////        'Add Event': function () {

            ////            var what = jQuery.trim($("#what").val());
            ////            var Other = jQuery.trim($("#Other").val());

            ////            if (what == "") {
            ////                alert("Please enter a short event description into the \"what\" field.");
            ////            }
            ////            else if (Other == "") {
            ////                alert("Please enter other information into the \"other\" field.");
            ////            }
            ////            else {

            ////                var startDate = $("#startDate").val();
            ////                var startDtArray = startDate.split("-");
            ////                var startYear = startDtArray[0];
            ////                // jquery datepicker months start at 1 (1=January)		
            ////                var startMonth = startDtArray[1];
            ////                var startDay = startDtArray[2];
            ////                // strip any preceeding 0's		
            ////                startMonth = startMonth.replace(/^[0]+/g, "");
            ////                startDay = startDay.replace(/^[0]+/g, "");
            ////                var startHour = jQuery.trim($("#startHour").val());
            ////                var startMin = jQuery.trim($("#startMin").val());
            ////                var startMeridiem = jQuery.trim($("#startMeridiem").val());
            ////                startHour = parseInt(startHour.replace(/^[0]+/g, ""));
            ////                if (startMin == "0" || startMin == "00") {
            ////                    startMin = 0;
            ////                } else {
            ////                    startMin = parseInt(startMin.replace(/^[0]+/g, ""));
            ////                }
            ////                if (startMeridiem == "AM" && startHour == 12) {
            ////                    startHour = 0;
            ////                } else if (startMeridiem == "PM" && startHour < 12) {
            ////                    startHour = parseInt(startHour) + 12;
            ////                }

            ////                var endDate = $("#endDate").val();
            ////                var endDtArray = endDate.split("-");
            ////                var endYear = endDtArray[0];
            ////                // jquery datepicker months start at 1 (1=January)		
            ////                var endMonth = endDtArray[1];
            ////                var endDay = endDtArray[2];
            ////                // strip any preceeding 0's		
            ////                endMonth = endMonth.replace(/^[0]+/g, "");

            ////                endDay = endDay.replace(/^[0]+/g, "");
            ////                var endHour = jQuery.trim($("#endHour").val());
            ////                var endMin = jQuery.trim($("#endMin").val());
            ////                var endMeridiem = jQuery.trim($("#endMeridiem").val());
            ////                endHour = parseInt(endHour.replace(/^[0]+/g, ""));
            ////                if (endMin == "0" || endMin == "00") {
            ////                    endMin = 0;
            ////                } else {
            ////                    endMin = parseInt(endMin.replace(/^[0]+/g, ""));
            ////                }
            ////                if (endMeridiem == "AM" && endHour == 12) {
            ////                    endHour = 0;
            ////                } else if (endMeridiem == "PM" && endHour < 12) {
            ////                    endHour = parseInt(endHour) + 12;
            ////                }

            ////                //Add to Database
            ////                var event = new Object();
            ////                event.eventName = what;
            ////                event.otherInfo = Other;
            ////                event.startYear = startYear;
            ////                event.startMonth = startMonth;
            ////                event.startDay = startDay;
            ////                event.startHour = startHour;
            ////                event.startMin = startMin;

            ////                event.endYear = endYear;
            ////                event.endMonth = endMonth;
            ////                event.endDay = endDay;
            ////                event.endHour = endHour;
            ////                event.endMin = endMin;

            ////                event.backgroundColor = $("#colorBackground").val();
            ////                event.foregroundColor = $("#colorForeground").val();

            ////                $.ajax({
            ////                    type: "POST",
            ////                    contentType: "application/json",
            ////                    data: "{eventdata:" + JSON.stringify(event) + "}",
            ////                    url: "MyCalender.aspx/SaveEvent",
            ////                    dataType: "json",
            ////                    success: function (data) {
            ////                        DisplayCalData();                                  
                                    
            ////                    },
            ////                    error: function (XMLHttpRequest, textStatus, errorThrown) {
            ////                        debugger;
            ////                    }
            ////                });
            ////                //End
            ////                //alert("Start time: " + startHour + ":" + startMin + " " + startMeridiem + ", End time: " + endHour + ":" + endMin + " " + endMeridiem);

            ////                $(this).dialog('close');

            ////            }

            ////        },
            ////        Cancel: function () {
            ////            $(this).dialog('close');
            ////        }
            ////    },
            ////    open: function (event, ui) {
            ////        // initialize start date picker
            ////        $("#startDate").datepicker({
            ////            showOtherMonths: true,
            ////            selectOtherMonths: true,
            ////            changeMonth: true,
            ////            changeYear: true,
            ////            showButtonPanel: true,
            ////            dateFormat: 'yy-mm-dd'
            ////        });
            ////        // initialize end date picker
            ////        $("#endDate").datepicker({
            ////            showOtherMonths: true,
            ////            selectOtherMonths: true,
            ////            changeMonth: true,
            ////            changeYear: true,
            ////            showButtonPanel: true,
            ////            dateFormat: 'yy-mm-dd'
            ////        });
            ////        // initialize with the date that was clicked
            ////        $("#startDate").val(clickDate);
            ////        $("#endDate").val(clickDate);
            ////        // initialize color pickers
            ////        $("#colorSelectorBackground").ColorPicker({
            ////            color: "#333333",
            ////            onShow: function (colpkr) {
            ////                $(colpkr).css("z-index", "10000");
            ////                $(colpkr).fadeIn(500);
            ////                return false;
            ////            },
            ////            onHide: function (colpkr) {
            ////                $(colpkr).fadeOut(500);
            ////                return false;
            ////            },
            ////            onChange: function (hsb, hex, rgb) {
            ////                $("#colorSelectorBackground div").css("backgroundColor", "#" + hex);
            ////                $("#colorBackground").val("#" + hex);
            ////            }
            ////        });
            ////        //$("#colorBackground").val("#1040b0");		
            ////        $("#colorSelectorForeground").ColorPicker({
            ////            color: "#ffffff",
            ////            onShow: function (colpkr) {
            ////                $(colpkr).css("z-index", "10000");
            ////                $(colpkr).fadeIn(500);
            ////                return false;
            ////            },
            ////            onHide: function (colpkr) {
            ////                $(colpkr).fadeOut(500);
            ////                return false;
            ////            },
            ////            onChange: function (hsb, hex, rgb) {
            ////                $("#colorSelectorForeground div").css("backgroundColor", "#" + hex);
            ////                $("#colorForeground").val("#" + hex);
            ////            }
            ////        });
            ////        //$("#colorForeground").val("#ffffff");				
            ////        // put focus on first form input element
            ////        $("#what").focus();
            ////    },
            ////    close: function () {
            ////        // reset form elements when we close so they are fresh when the dialog is opened again.
            ////        $("#startDate").datepicker("destroy");
            ////        $("#endDate").datepicker("destroy");
            ////        $("#startDate").val("");
            ////        $("#endDate").val("");
            ////        $("#startHour option:eq(0)").attr("selected", "selected");
            ////        $("#startMin option:eq(0)").attr("selected", "selected");
            ////        $("#startMeridiem option:eq(0)").attr("selected", "selected");
            ////        $("#endHour option:eq(0)").attr("selected", "selected");
            ////        $("#endMin option:eq(0)").attr("selected", "selected");
            ////        $("#endMeridiem option:eq(0)").attr("selected", "selected");
            ////        $("#what").val("");
            ////        //$("#colorBackground").val("#1040b0");
            ////        //$("#colorForeground").val("#ffffff");
            ////    }
            ////});

            /**
             * Initialize display event form.
             */
            $("#display-event-form").dialog({
                autoOpen: false,
                height: 400,
                width: 400,
                modal: true,
                buttons: {
                    Cancel: function () {
                        $(this).dialog('close');
                        //},
                        //'Edit': function () {
                        //  alert("Make your own edit screen or dialog!");
                    },
                    //'Delete': function () {
                    //    if (confirm("Are you sure you want to delete this agenda item?")) {
                    //        if (clickAgendaItem != null) {
                    //            jfcalplugin.deleteAgendaItemById("#mycal", clickAgendaItem.agendaId);
                    //            //jfcalplugin.deleteAgendaItemByDataAttr("#mycal","myNum",42);
                    //            //alert(clickAgendaItem.data.ID);
                    //            //Start Database Delete
                    //            $.ajax({
                    //                type: "POST",
                    //                contentType: "application/json",
                    //                data: "{evid:" + JSON.stringify(clickAgendaItem.data.ID) + "}",
                    //                url: "MyCalender.aspx/DelEvent",
                    //                dataType: "json",
                    //                success: function (data) {
                    //                    DisplayCalData();

                    //                },
                    //                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    //                    debugger;
                    //                }
                    //            });
                    //            //End Database Delete
                    //        }
                    //        $(this).dialog('close');
                    //    }
                    //}
                },
                open: function (event, ui) {
                    if (clickAgendaItem != null) {
                        var title = clickAgendaItem.title;
                        var startDate = clickAgendaItem.startDate;
                        var endDate = clickAgendaItem.endDate;
                        var allDay = clickAgendaItem.allDay;
                        var result = clickAgendaItem.data;
                        var eID = result.ID;
                       
                        // in our example add agenda modal form we put some fake data in the agenda data. we can retrieve it here.
                        var startDate = new Date(startDate + " UTC");
                        startDate = startDate.toString().replace(/GMT.*/g, "");
                        var endDate = new Date(endDate + " UTC");
                        endDate = endDate.toString().replace(/GMT.*/g, "");
                        $("#display-event-form").append(
                            "<br><b>" + title + "</b><br><br>"
                        );
                        if (allDay) {
                            $("#display-event-form").append(
                                "(All day event)<br><br>"
                            );
                        } else {
                            $("#display-event-form").append(
                                "<b>Start Date:</b> " + startDate + "<br>" +
                                "<b>End Date  :</b> " + endDate + "<br><br>"
                            );
                        }
                        //for (var propertyName in result) {
                        //    //if (propertyName != "ID")
                        //        $("#display-event-form").append("<b>" + propertyName + ":</b> " + result[propertyName] + "<br>");
                        //}
                 
                        //Start Database
                        
                            $.ajax({
                                contentType: "application/json; charset=utf-8",
                                data: "{evid:" + JSON.stringify(clickAgendaItem.data.ID) + "}",
                                dataType: "json",
                                type: "POST",
                                url: "MyCalender.aspx/ViewDetails",                                        //the code behind method
                                success: function (data) {                                                  //using the value returned by the code behind in a for loop to print all the existing events from the DB
                                    for (var i = 0; i < data.d.length; i++) {
                                        for (var propertyName in data.d[i]) {
                                            if (data.d[i][propertyName] != null && propertyName != '__type' && propertyName!='eventID')
                                            $("#display-event-form").append("<b>" + propertyName + ":</b> " + data.d[i][propertyName] + "<br>");
                                        }
                                        //alert(data.d[i].otherInfo.toString());
                                    }
                                },
                                error: function (result) {
                                    alert(result.responseText);
                                }
                            });
                        //End Database
                    }
                },
                close: function () {
                    // clear agenda data
                    $("#display-event-form").html("");
                }
            });

            /**
             * Initialize our tabs
             */
            $("#tabs").tabs({
                /*
                 * Our calendar is initialized in a closed tab so we need to resize it when the example tab opens.
                 */
                show: function (event, ui) {
                    if (ui.index == 1) {
                        jfcalplugin.doResize("#mycal");
                    }
                }
            });

            //Month Name
            function myFunction(monthName) {
                var month = new Array();
                month[0] = "January";
                month[1] = "February";
                month[2] = "March";
                month[3] = "April";
                month[4] = "May";
                month[5] = "June";
                month[6] = "July";
                month[7] = "August";
                month[8] = "September";
                month[9] = "October";
                month[10] = "November";
                month[11] = "December";
               
                var n = month[monthName];
                return n;
            }
            //End Month Name
        });
