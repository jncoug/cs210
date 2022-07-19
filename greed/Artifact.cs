
    /// <summary>
    /// <para>An item of cultural or historical interest.</para>
    /// <para>
    /// The responsibility of an Gem is to provide a message about itself.
    /// </para>
    /// </summary>

    public class Artifact : Actor // inherits everything from Actor class
        {
            private string message = ""; // add an additional attribute to the class
            private int points = 50;

            // 2) Create the class constructor. Use the following method comment.
        
            /// <summary>
            /// Constructs a new instance of Artifact.
            /// </summary>
            public Artifact()
            {

            }

            public string GetMessage()
            {
                return message;
            }

            public void SetMessage(string message)
            {
                this.message = message;
            }

            public int GetPoints()
            {
                return points;
            }

            public void SetPoints(int points)
            {
                this.points = points;
            }
        }


