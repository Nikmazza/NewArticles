function __Articles_SectionShowHideOnCheck(sInputControlID, sContentID)
{
	var oInputControl = dnn.dom.getById(sInputControlID);
	var oContent = dnn.dom.getById(sContentID);

	if (oInputControl == null) { 
		alert('Specified Input Control Not Found'); }
	else {
		if (oInputControl.checked)
		{
			oContent.style.display = '';
		}
		else
		{
			oContent.style.display = 'none';
		}
	}
	return true;	//cancel postback
}

function __Articles_showHideOtherModule(val, sContainerID) {
	var obj = dnn.dom.getById(sContainerID);
	if (val=="OtherModule") {
		obj.style.display = '';
	} else {
		obj.style.display = 'none';
	};
}