namespace ZezinhoBot
{
    class BotResponseModel
    {
        public Intent[] intents { get; set; }
        public object[] entities { get; set; }
        public Input input { get; set; }
        public Output output { get; set; }
        public Context context { get; set; }
        public bool alternate_intents { get; set; }

        public class Input
        {
            public string text { get; set; }
        }

        public class Output
        {
            public Generic[] generic { get; set; }
            public string[] text { get; set; }
            public string[] nodes_visited { get; set; }
            public object[] log_messages { get; set; }
        }

        public class Generic
        {
            public string response_type { get; set; }
            public string text { get; set; }
        }

        public class Context
        {
            public string conversation_id { get; set; }
            public System system { get; set; }
        }

        public class System
        {
            public Dialog_Stack[] dialog_stack { get; set; }
            public long dialog_turn_counter { get; set; }
            public long dialog_request_counter { get; set; }
            public _Node_Output_Map _node_output_map { get; set; }
            public bool branch_exited { get; set; }
            public string branch_exited_reason { get; set; }
        }

        public class _Node_Output_Map
        {
            public Node_1_1534967239906 node_1_1534967239906 { get; set; }
        }

        public class Node_1_1534967239906
        {
            public long[] _1 { get; set; }
        }

        public class Dialog_Stack
        {
            public string dialog_node { get; set; }
        }

        public class Intent
        {
            public string intent { get; set; }
            public long confidence { get; set; }
        }

    }
}
