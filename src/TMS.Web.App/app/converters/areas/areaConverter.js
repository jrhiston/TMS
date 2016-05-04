export default function xhrToAreaConverter(xhr) {
    var area = JSON.parse(xhr.responseText)[0]

    return {
        areaId: area.AreaId,
        created: area.Created,
        description: area.Description,
        name: area.Name
    }
}
