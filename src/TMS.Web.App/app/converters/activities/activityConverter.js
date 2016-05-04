export default function xhrToActivityConverter(xhr) {
    var activity = JSON.parse(xhr.responseText)[0]

    return {
        areaId: activity.ActivityId,
        created: activity.Created,
        description: activity.Description,
        name: activity.Name
    }
}
