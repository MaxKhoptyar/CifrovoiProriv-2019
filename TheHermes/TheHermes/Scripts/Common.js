function _enum_(_name, Elems) {
    var elem, value;
    window[_name] = {};
    for (var i = Elems.length; i--;) {
        elem = Elems[i];
        value = elem.replace(/\s/g, '').split('=');
        window[_name][value[0]] = {
            value: value[0],
            int: value[1] | i,
            toString: function () {
                return this.value;
            }
        };
    }
}


_enum_(
  'MessageType',
  ['Warning', 'Error', 'Information', 'Success']);

function ShowAllertMessage(elemId, caption, message, msgType) {
    if (!$('#' + elemId).hasClass('alert')) {
        $('#' + elemId).addClass('alert');
    }
    removeAlertClasses(elemId);
    switch (msgType) {
        case window.MessageType.Warning:;
            $('#' + elemId).addClass('alert-warning');
            break;
        case window.MessageType.Error:
            $('#' + elemId).addClass('alert-danger');
            break;
        case window.MessageType.Information:
            $('#' + elemId).addClass('alert-info');
            break;
        case window.MessageType.Success:
            $('#' + elemId).addClass('alert-success');
            break;
        default:
            $('#' + elemId).addClass('alert-success');
            break;
    }

    $('#' + elemId).html('<a class="close" onclick="closeAlert(\'' + elemId + '\');">×</a> <strong>' + caption + '</strong> ' + message);
    $('#' + elemId).show();
    setTimeout(function () {
        $('#' + elemId).fadeOut();
    }, 10000);
}

function closeAlert(elementId) {
    $('#' + elementId).hide();
    removeAlertClasses(elementId);
}

function removeAlertClasses(elemId) {
    if ($('#' + elemId).hasClass('alert-danger')) {
        $('#' + elemId).removeClass('alert-danger');
    }
    if ($('#' + elemId).hasClass('alert-success')) {
        $('#' + elemId).removeClass('alert-success');
    }
    if ($('#' + elemId).hasClass('alert-warning')) {
        $('#' + elemId).removeClass('alert-warning');
    }
    if ($('#' + elemId).hasClass('alert-info')) {
        $('#' + elemId).removeClass('alert-info');
    }

}

function LoadingStart(loadingString) {
    if ($('body').length) {
        if (loadingString != undefined && loadingString.length > 0) {
            $('body').append('<div id="parent_loading"><div id="loading_center"><div id="loading_center"></div><div style = "display: inline;"><span style="color: white;">' + loadingString + '</span></div></div><div>');
        } else {
            $('body').append('<div id="parent_loading"><div id="loading_center"><div id="loading_body"></div></div><div>');
        }
    }
}

function LoadingEnd() {
    $('#parent_loading').remove();
}

var commonErrorMessage = "Повторите операцию позже или обратитесь к администратору";

_enum_('AlertType', ['Warning', 'Error', 'Info', 'Success']);

var alertRebornNumber = 0;

function ShowAlert(title, message, type, time, isNeedTime, needId) {

    if (time == undefined || time < 0) {
        time = 55000;
    }
    var alertClass = '';
    switch (type) {
        case window.AlertType.Warning:;
            alertClass = 'alert-warning';
            break;
        case window.AlertType.Error:
            alertClass = 'alert-danger';
            break;
        case window.AlertType.Info:
            alertClass = 'alert-info';
            break;
        case window.AlertType.Success:
            alertClass = 'alert-success';
            break;
        default:
            alertClass = 'alert-info';
            break;
    }
    if (!$('#alert-body').length) {
        $('body').append('<div id="alert-body" class="reborn-alert"></div>');
    }
    if (title == undefined) {
        title = 'Уведомление';
    }
    alertRebornNumber++;
    var id = 'alert-' + alertRebornNumber;
    if (needId != undefined && needId != "") {
        id = 'alert-' + needId;
    }
    var text = '<div id="' + id + '" class="alert alert-block ' + alertClass + ' ">' +
        '<a class="close" data-dismiss="alert" href="#">X</a>' +
            '<h4>' +
                '<span class="fa fa-warning"></span>' + title +
            '</h4>' +
            '<label>' + message + '</label>' +
        '</div>';
    $('#alert-body').append(text);
    if (isNeedTime == undefined || isNeedTime == true) {
        setTimeout(function () {
            $('#' + id).remove();
        }, time);
    }
}

function UpdateUserInfo() {
    var selectedOrganisation = $('#organistaionSelect').val();
    var childrenCount = $('#childrenCount').val();
    var age = $('#age').val();


    $.ajax({
        url: '/User/UpdateUserInfo',
        type: "POST",
        data: { "SelectedOrganisation": selectedOrganisation, "ChildrenCount": childrenCount, "Age": age },
        success: function (result) {
            if (!result.success) {
                ShowAlert('Ошибка!', result.message, window.AlertType.Error, 3000);
            } else {
                ShowAlert('Успех!', result.message, window.AlertType.Success, 3000);
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            ShowAlert('Ошибка!', window.commonErrorMessage, window.AlertType.Error, 2000);
        }
    });
}

function CreateClaim() {
    var claimSelect = $('#claimSelect').val();
    var accompanyingMessage = $('#accompanyingMessage').val();

    $.ajax({
        url: '/Claim/CreateClaim',
        type: "POST",
        data: { "SelectedClaimType": claimSelect, "AccompanyingMessage": accompanyingMessage },
        success: function (result) {
            if (!result.success) {
                ShowAlert('Ошибка!', result.message, window.AlertType.Warning, 3000);
            } else {
                if (result.isMerge) {
                    ShowAlert('Успех!', result.message, window.AlertType.Info, 3000);
                } else {
                    ShowAlert('Успех!', result.message, window.AlertType.Success, 3000);
                }
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            ShowAlert('Ошибка!', window.commonErrorMessage, window.AlertType.Error, 2000);
        }
    });
}

function WorkWithClaim(claimId) {
    window.location.href = '/Claim/WorkWithClaim?claimId=' + claimId;
}

function OpenRatingClaim(claimId) {
    $.ajax({
        url: '/Claim/OpenRatingClaim',
        type: "POST",
        data: { "claimId": claimId },
        success: function (result) {
            if (!result.success) {
                ShowAlert('Ошибка!', result.message, window.AlertType.Warning, 3000);
            } else {
                ShowAlert('Успех!', result.message, window.AlertType.Info, 3000);
                window.location.href = '/Claim/AdministrationClaim';
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            ShowAlert('Ошибка!', window.commonErrorMessage, window.AlertType.Error, 2000);
        }
    });
}

function CloseRatingClaim(claimId) {
    $.ajax({
        url: '/Claim/CloseRatingClaim',
        type: "POST",
        data: { "claimId": claimId },
        success: function (result) {
            if (!result.success) {
                ShowAlert('Ошибка!', result.message, window.AlertType.Warning, 3000);
            } else {
                ShowAlert('Успех!', result.message, window.AlertType.Success, 3000);
                window.location.href = '/Claim/AdministrationClaim';
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            ShowAlert('Ошибка!', window.commonErrorMessage, window.AlertType.Error, 2000);
        }
    });
}

function GetNotification() {
    $.ajax({
        url: '/Notification/GetNotification',
        type: "POST",
        data: { },
        success: function (result) {
            if (!result.success) {

            } else {
                if (result.count > 0) {
                    $('#notificationBadge').html(result.count);
                }
            }
        }
    });
}

function CollaborateClaimAction(claimId) {
    window.location.href = '/Claim/CollaborateClaimAction?claimId=' + claimId;
}
function RatingClaimAction(claimId) {
    window.location.href = '/Claim/RatingClaimAction?claimId=' + claimId;
}
function AnswerClaimAction(claimId) {
    window.location.href = '/Claim/AnswerClaimAction?claimId=' + claimId;
}

function NotificationIndex() {
    window.location.href = '/Notification/Index';
}

function CollaborateClaim(claimId) {
    var accompanyingMessage = $('#accompanyingMessage').val();

    $.ajax({
        url: '/Claim/CollaborateClaim',
        type: "POST",
        data: { "ClaimId": claimId, "AccompanyingMessage": accompanyingMessage },
        success: function (result) {
            if (!result.success) {
                ShowAlert('Ошибка!', result.message, window.AlertType.Warning, 3000);
            } else {
                if (result.isMerge) {
                    ShowAlert('Успех!', result.message, window.AlertType.Info, 3000);
                } else {
                    ShowAlert('Успех!', result.message, window.AlertType.Success, 3000);
                }
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            ShowAlert('Ошибка!', window.commonErrorMessage, window.AlertType.Error, 2000);
        }
    });
}

function CreateRatingClaim(claimId) {
    var accompanyingMessage = $('#accompanyingMessage').val();
    var ratingId = $('#ratingSelect').val();
    
    $.ajax({
        url: '/Claim/RatingClaim',
        type: "POST",
        data: { "ClaimId": claimId, "AccompanyingMessage": accompanyingMessage, "Rating": ratingId },
        success: function (result) {
            if (!result.success) {
                ShowAlert('Ошибка!', result.message, window.AlertType.Warning, 3000);
            } else {
                if (result.isMerge) {
                    ShowAlert('Успех!', result.message, window.AlertType.Info, 3000);
                } else {
                    ShowAlert('Успех!', result.message, window.AlertType.Success, 3000);
                }
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            ShowAlert('Ошибка!', window.commonErrorMessage, window.AlertType.Error, 2000);
        }
    });
}