////window.initializeDataTable = () => {
////    $(document).ready(function () {
////        $('#dataTable').DataTable({
////            paging: true,
////            searching: true,
////            ordering: true,
////            info: true,
////        });
////    });
////};

////window.initializeDataTable = () => {
////    $(document).ready(function () {
////        $('#myTable').DataTable({
////            paging: true,
////            searching: true,
////            ordering: true,
////            info: true,
////            ajax: {
////                url: 'https://localhost:7230/api/Coa/all', // Replace with your API endpoint
////                dataSrc: ''
////            },
////            columns: [
////                { data: 'id', title: '#' }, // # Column
////                {
////                    data: 'orderCopy',
////                    title: 'PO Copy Receive Date',
////                    render: function (data) {
////                        return new Date(data).toLocaleDateString(); // Format date
////                    }
////                },
////                { data: 'receivedBy', title: 'Received By' },
////                {
////                    data: 'inspectionRequest',
////                    title: 'Inspection Request Date',
////                    render: function (data) {
////                        return new Date(data).toLocaleDateString(); // Format date
////                    }
////                },
////                { data: 'inspectionReceivedBy', title: 'Inspection Received By' },
////                {
////                    data: null,
////                    title: 'Action',
////                    orderable: false,
////                    render: function (data, type, row) {
////                        return `
////                            <button class="btn btn-primary btn-sm" onclick="editCoa(${row.Id})">Edit</button>
////                            <button class="btn btn-danger btn-sm" onclick="deleteCoa(${row.Id})">Delete</button>
////                        `;
////                    }
////                }
////            ]
////        });
////    });
////};

////// JavaScript functions for actions
////window.editCoa = (id) => {
////    console.log(`Edit Coa with ID: ${id}`);
////    // Implement edit logic here
////};

////window.deleteCoa = (id) => {
////    console.log(`Delete Coa with ID: ${id}`);
////    // Implement delete logic here
////};

//// Function to destroy DataTable instance
//window.destroyDataTable = () => {
//    const table = $('#myTable').DataTable();
//    if (table) {
//        table.destroy();
//        $('#myTable').empty(); // Clear the table to prevent conflicts
//    }
//};

//// Initialize the DataTable
//window.initializeDataTable = () => {
//    $(document).ready(function () {
//        if ($.fn.DataTable.isDataTable('#myTable')) {
//            $('#myTable').DataTable().destroy(); // Ensure no duplicate initialization
//        }

//        $('#myTable').DataTable({
//            paging: true,
//            searching: true,
//            ordering: true,
//            info: true,
//            ajax: {
//                url: 'https://localhost:7230/api/Coa/all', // Replace with your API endpoint
//                dataSrc: ''
//            }
//            //columns: [
//            //    { data: 'id', title: '#' }, // ID Column
//            //    {
//            //        data: 'orderCopy',
//            //        title: 'PO Copy Receive Date',
//            //        render: function (data) {
//            //            return data ? new Date(data).toLocaleDateString() : 'N/A'; // Format date
//            //        }
//            //    },
//            //    { data: 'receivedBy', title: 'Received By' },
//            //    {
//            //        data: 'inspectionRequest',
//            //        title: 'Inspection Request Date',
//            //        render: function (data) {
//            //            return data ? new Date(data).toLocaleDateString() : 'N/A'; // Format date
//            //        }
//            //    },
//            //    { data: 'inspectionReceivedBy', title: 'Inspection Received By' },
//                //{
//                //    data: null,
//                //    title: 'Action',
//                //    orderable: false,
//                //    render: function (data, type, row) {
//                //        return `
//                //            <button class="btn btn-primary btn-sm" style="text-align: center" @onclick="() => EditClicked(item)")">Edit</button>
//                //            <button class="btn btn-danger btn-sm" style="text-align: center" @onclick="() => DeleteClicked(item)">Delete</button>
//                //        `;
//                //    }
//                //}
//           /* ]*/
//        });
//    });
//};

 
