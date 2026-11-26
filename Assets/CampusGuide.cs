using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class CampusGuide : MonoBehaviour
{
    private sealed class Building
    {
        public readonly string Name;
        public readonly string Location;
        public readonly string Description;
        public readonly Rect MapMarker;

        public Building(string name, string location, string description, Rect mapMarker)
        {
            Name = name;
            Location = location;
            Description = description;
            MapMarker = mapMarker;
        }
    }

    private static readonly Building[] Buildings =
    {
        new Building("Recepcja", "Budynek A · parter",
            "Pierwszy punkt po wejściu na kampus. Tutaj uzyskasz informację o salach, planie zajęć i obsłudze studenta.",
            new Rect(78, 340, 170, 98)),
        new Building("Biblioteka", "Budynek B · 1. piętro",
            "Wypożyczysz książki, skorzystasz z czytelni i znajdziesz miejsce do pracy indywidualnej.",
            new Rect(452, 99, 202, 121)),
        new Building("Laboratoria", "Budynek C · 2. piętro",
            "Tu odbywają się zajęcia praktyczne. Dostęp do pracowni komputerowych koordynuje prowadzący.",
            new Rect(412, 344, 210, 111))
    };

    private static readonly Color Ink = new Color32(24, 42, 42, 255);
    private static readonly Color Paper = new Color32(243, 244, 233, 255);
    private static readonly Color Teal = new Color32(29, 100, 91, 255);
    private static readonly Color PaleTeal = new Color32(226, 238, 226, 255);
    private static readonly Color Lime = new Color32(203, 233, 145, 255);
    private static readonly Color White = new Color32(255, 255, 249, 255);

    private int selected = -1;
    private GUIStyle heading;
    private GUIStyle subheading;
    private GUIStyle body;
    private GUIStyle caption;
    private GUIStyle marker;
    private GUIStyle directoryItem;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void StartGuide()
    {
        if (SceneManager.GetActiveScene().name == "CampusGuide")
            new GameObject("Campus Guide").AddComponent<CampusGuide>();
    }

    private void OnGUI()
    {
        if (heading == null)
        {
            heading = TextStyle(42, FontStyle.Bold);
            subheading = TextStyle(26, FontStyle.Bold);
            body = TextStyle(19);
            caption = TextStyle(16, FontStyle.Bold);
            marker = TextStyle(20, FontStyle.Bold, TextAnchor.MiddleCenter);
            directoryItem = TextStyle(19, FontStyle.Bold, TextAnchor.MiddleLeft);
            directoryItem.padding.left = 18;
        }

        Paint(new Rect(0, 0, Screen.width, Screen.height), Paper);
        float scale = Mathf.Min(Screen.width / 1200f, Screen.height / 750f);
        Matrix4x4 oldMatrix = GUI.matrix;
        Vector3 offset = new Vector3((Screen.width - 1200 * scale) / 2, (Screen.height - 750 * scale) / 2);
        GUI.matrix = Matrix4x4.TRS(offset, Quaternion.identity, new Vector3(scale, scale, 1));

        GUI.Label(new Rect(40, 35, 700, 56), "Przewodnik po kampusie", heading);
        GUI.Label(new Rect(42, 99, 700, 30), "Wybierz budynek na mapie lub z listy.", body);
        DrawMap();
        DrawDirectory();
        GUI.Label(new Rect(42, 703, 715, 26), "Demonstrator · przykładowy układ kampusu", caption);
        GUI.matrix = oldMatrix;
    }

    private void DrawMap()
    {
        GUI.BeginGroup(new Rect(40, 152, 746, 528));
        Paint(new Rect(0, 0, 746, 528), PaleTeal);
        GUI.Label(new Rect(24, 20, 220, 32), "Mapa kampusu", caption);
        GUI.Label(new Rect(678, 20, 60, 32), "↑ N", caption);

        Color pathColor = new Color32(255, 251, 230, 255);
        Paint(new Rect(39, 271, 668, 46), pathColor);
        Paint(new Rect(137, 317, 35, 177), pathColor);
        Paint(new Rect(517, 110, 40, 277), pathColor);
        Paint(new Rect(290, 90, 34, 227), pathColor);
        Paint(new Rect(269, 108, 80, 90), new Color32(173, 202, 161, 255));
        Paint(new Rect(85, 115, 145, 116), new Color32(182, 209, 174, 255));
        Paint(new Rect(300, 372, 72, 79), new Color32(182, 209, 174, 255));
        Paint(new Rect(642, 357, 44, 104), new Color32(173, 202, 161, 255));
        GUI.Label(new Rect(71, 490, 180, 27), "Wejście główne", caption);

        for (int i = 0; i < Buildings.Length; i++)
        {
            Building building = Buildings[i];
            if (DrawButton(building.MapMarker, building.Name, marker, i == selected, Teal))
                selected = i;
        }
        GUI.EndGroup();
    }

    private void DrawDirectory()
    {
        Paint(new Rect(812, 152, 348, 528), White);
        GUI.Label(new Rect(836, 176, 300, 42), "Budynki", subheading);
        for (int i = 0; i < Buildings.Length; i++)
        {
            if (DrawButton(new Rect(836, 225 + i * 58, 300, 48),
                Buildings[i].Name, directoryItem, i == selected, PaleTeal))
                selected = i;
        }

        Paint(new Rect(836, 417, 300, 2), PaleTeal);
        if (selected < 0)
        {
            GUI.Label(new Rect(836, 448, 300, 100), "Po wyborze zobaczysz lokalizację i opis budynku.", body);
            return;
        }

        Building building = Buildings[selected];
        GUI.Label(new Rect(836, 444, 300, 38), building.Name, subheading);
        GUI.Label(new Rect(836, 494, 300, 28), building.Location, caption);
        GUI.Label(new Rect(836, 540, 300, 115), building.Description, body);
    }

    private static bool DrawButton(Rect bounds, string label, GUIStyle style, bool active, Color fallback)
    {
        Color background = active ? Lime : fallback;
        bool hovering = bounds.Contains(Event.current.mousePosition);
        Paint(bounds, hovering ? Color.Lerp(background, White, 0.18f) : background);
        Color text = !active && fallback == Teal ? White : Ink;
        style.normal.textColor = text;
        style.hover.textColor = text;
        style.active.textColor = text;
        style.focused.textColor = text;
        return GUI.Button(bounds, label, style);
    }

    private static GUIStyle TextStyle(int size, FontStyle weight = FontStyle.Normal,
        TextAnchor alignment = TextAnchor.UpperLeft)
    {
        return new GUIStyle(GUI.skin.label)
        {
            fontSize = size,
            fontStyle = weight,
            alignment = alignment,
            wordWrap = true,
            normal = { textColor = Ink }
        };
    }

    private static void Paint(Rect bounds, Color color)
    {
        Color previous = GUI.color;
        GUI.color = color;
        GUI.DrawTexture(bounds, Texture2D.whiteTexture);
        GUI.color = previous;
    }
}
