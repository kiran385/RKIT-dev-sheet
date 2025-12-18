$(() => {
    var arrayStore = new DevExpress.data.ArrayStore({
        key: "id",
        data: [
            {
                "id": 1,
                "Name": "Ajay",
                "Age": 20
            },
            {
                "id": 2,
                "Name": "Jay",
                "Age": 21
            },
            {
                "id": 3,
                "Name": "Krish",
                "Age": 20
            },
            {
                "id": 4,
                "Name": "Sachin",
                "Age": 23
            }
        ],
        onLoading: function (loadOptions) {
            console.log("onLoading with loadOptions:", loadOptions);
        },
        onLoaded: function (result, loadOptions) {
            console.log("onLoaded:", result, "with loadOptions:", loadOptions);
        },
        onInserting: function (values) {
            console.log("onInserting", values);
        },
        onInserted: function (values, key) {
            console.log("onInserted Item:", values, "with key:", key);
        },
        onUpdating: function (key, values) {
            console.log("onUpdating item with key:", key, "to values:", values);
        },
        onUpdated: function (key, values) {
            console.log("onUpdated Item updated with key:", key, "to values:", values);
        },
        onRemoving: function (key) {
            console.log("onRemoving item with key:", key);
        },
        onRemoved: function (key) {
            console.log("onRemoved Item with key:", key);
        },
        onModifying: function (changes) {
            console.log("onModifying with changes:", changes);
        },
        onModified: function (changes) {
            console.log("onModified changes:", changes);
        },
        onPush: function (changes) {
            console.log("onPush changes:", changes);
        }
    });

    // Load data
    arrayStore.load().done(function (data) {
        console.log("load() method", data);
    });

    // Insert a new item
    arrayStore.insert({ id: 5, name: "Yash", age: 25 }).done(function () {
        console.log("Item inserted");
        arrayStore.load().done(function (data) {
            console.log("Loaded data after insertion:", data);
        });
    });

    // Update an item
    arrayStore.update(3, { Age: 36 }).done(function () {
        console.log("Item updated");
        arrayStore.load().done(function (data) {
            console.log("Loaded data after update:", data);
        });
    });

    // Remove an item
    arrayStore.remove(5).done(function () {
        console.log("Item removed");
        arrayStore.load().done(function (data) {
            console.log("Loaded data after removal:", data);
        });
    });

    // Get item by key
    arrayStore.byKey(2)
        .done(function (item) {
        console.log("Item with key", item.id, ": ", item);
        })
        .fail(function (error) {
            console.log("Error: ", error);
        });
});