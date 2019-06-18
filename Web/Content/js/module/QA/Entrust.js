var _time = 300;


function SaveWT() {
    var name = $("#txtName").val();
    var phone = $("#txtPhone").val();
    var code = $("#txtCode").val();
    var details = $("#txtDetails").val();

    if (name == "") {
        layermsg("请输入姓名");
        return;
    }
    if (name.length > 20) {
        layermsg("名字限制20字以内");
        return;
    }
    if (phone.length != 11) {
        layermsg("请输入正确的手机号");
        return;
    }
    if (!CheckPhone(phone)) {
        layermsg("请输入正确的手机号");
        return;
    }
    if (code == "") {
        layermsg("请输入验证码");
        return;
    }
    if (code.length >= 10) {
        layermsg("验证码长度不能超过10位");
        return;
    }
    if (details == "") {
        layermsg("请输入详情");
        return;
    }
    if (details.length > 500) {
        layermsg("详情不能超过500字");
        return;
    }
    $.ajax({
        type: 'POST',
        url: "/QA/SaveEntrust",
        data: $("#createForm").serialize(),
        beforeSend: function () {
            $("#btnWT").attr("disabled", "disabled");
            loadi = layer.load("数据提交中...");
        },
        success: function (data) {
            layer.close(loadi);
            $("#btnAdd").removeAttr("disabled");
            var handleResult = JsonEval(data);
            if (handleResult.StatsCode == 200) {
                layermsg(handleResult.Message, function () {
                    parent.layer.closeAll();
                });
            }
            else {
                layermsg(handleResult.Message);
            }
        },
        complete: function () {
            layer.close(loadi);
            $("#btnWT").removeAttr("disabled");
        }
    });
}

//检验手机号
function CheckPhone(phone) {
    var myreg = /^(((1[0-9]{1}[0-9]{1})|(18[0-9]{1}))+\d{8})$/;
    if (!myreg.test(phone)) {
        return false;
    }
    return true;
}

//发送验证码
function SendCode() {
    var phone = $("#txtPhone").val();
    if (phone.length != 11) {
        layermsg("请输入正确的手机号");
        return;
    }
    if (!CheckPhone(phone)) {
        layermsg("请输入正确的手机号");
        return;
    }
    _time = 300;
    $.ajax({
        type: 'POST',
        url: "/Commons/SendPhoneCode",
        data: {
            phone: phone
        },
        beforeSend: function () {
            loadi = layer.load("验证码发送中...");
        },
        success: function (data) {
            layer.close(loadi);
            var handleResult = JsonEval(data);
            if (handleResult.StatsCode == 200) {
                $("#btnSendCode").attr("disabled", "disabled");
                $("#btnSendCode").attr("class", "bg-gary95");
                intv = setInterval(function () { TimeClock(); }, 1000);
                layermsg(handleResult.Message);
            }
            else if (handleResult.StatsCode == 501) {
                layermsg(handleResult.Message);
            }
            else {
                layermsg(handleResult.Message);
            }
        },
        complete: function () {
            //$("#btnSendCode").removeAttr("disabled");
        }
    });
}


function TimeClock() {
    if (_time > 1) {
        _time--;
        $("#btnSendCode").text(_time + "秒后重试")
    }
    else if (_time == 1) {
        clearInterval(intv);
        _time = 0;
        $("#btnSendCode").removeAttr("disabled");
        $("#btnSendCode").attr("class", "");
        $("#btnSendCode").text("获取验证码");
    }
}

