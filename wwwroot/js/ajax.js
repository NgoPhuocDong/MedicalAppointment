// phân quyền cho tài khoản
function SaveGrantPermissions(UserId, RoleId) {
    var jsonData = {
        UserId : UserId,
        RoleId: RoleId
    }
    $.ajax({
        url: '/Admin/User/GrantPermissions',
        type: 'post',
        data: jsonData,
        dataType: 'JSON',
        success: function (data) {
            alert(data.status);
        }
    })
}
//form chọn ca cho bác sĩ
//function SaveGrantShift() {
//    // Lấy dữ liệu từ các input trong form
//    var formData = {
//        UserId: $('#userid').val(), // Giả sử #Id là id của select
//        Date: $('#datetime').val(), // Giả sử #datetime là id của input date
//        TimeSlot: [] // Mảng lưu trữ các giá trị của checkbox được chọn
//    };

//    // Lặp qua các checkbox để lấy giá trị của các checkbox được chọn
//    $('input[type="checkbox"]:checked').each(function() {
//        formData.TimeSlot.push($(this).val());
//    });

//    // Gửi request AJAX lên server
//    $.ajax({
//        url: '/Admin/Doctor/GrantShift',
//        type: 'post',
//        data: JSON.stringify(formData),
//        contentType: 'application/json',
//        success: function (data) {
//            alert(data.status);
//        },
//        error: function (xhr, status, error) {
//            console.error('Error:', error);
//        }
//    });
//}
//lưu hình ảnh đại diện
function submitImage() {
    const result = confirm("Bạn muốn đổi ảnh đại diện?");

    if (result) {
        // Cách 2: Gọi trực tiếp submit() trên biểu mẫu
        const form = document.getElementById('profile-form');
        form.submit();
    } else {
        // Nút "Cancel" được nhấp
        // Không làm gì
    }
}

//form lọc dữ liệu
//function SubmitForm(genderId) {
//    const form = document.getElementById(genderId);
//    form.submit();
//}

//$('input [type="checkbox"] [name="gender"]').on('change', function () {
//    var selectedGender = $('input[type="checkbox"] [name="gender"]: checked').map(function () {
//        return $(this).val();
//    }).get();

//    $.ajax({
//        url: '/Doctor/GetFilteredDoctor',
//        type: 'POST',
//        dataType: 'html',
//        data: {
//            gender: selectedGender
//        }，
//        success: function (result) {
//            $("#doctor-list").html(result);
//        },
//        error: function () {
//            console.log('An error occurred while retrieving filtered product data.');
//        }
//    });
//});



