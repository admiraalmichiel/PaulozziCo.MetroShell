using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Interactivity;
using System.Collections.Generic;

namespace PaulozziCo.MetroShell.Presentation.Behaviors
{

    public class Behaviors : List<Behavior>
    {
        public Behaviors()
        {
            
        }
        public Behaviors(int capacity)
            : base(capacity)
        {
            
        }
        public Behaviors(IEnumerable<Behavior> collection)
            : base(collection)
        {
            
        }
    }

    public class Triggers : List<System.Windows.Interactivity.TriggerBase>
    {
        public Triggers()
        {
            
        }
        public Triggers(int capacity)
            : base(capacity)
        {
            
        }
        public Triggers(IEnumerable<System.Windows.Interactivity.TriggerBase> collection)
            : base(collection)
        {
            
        }
    }

    public static class SupplementaryInteraction
    {
        public static Behaviors GetBehaviors(DependencyObject obj)
        {
            return (Behaviors)obj.GetValue(BehaviorsProperty);
        }

        public static void SetBehaviors(DependencyObject obj, Behaviors value)
        {
            obj.SetValue(BehaviorsProperty, value);
        }

        public static readonly DependencyProperty BehaviorsProperty =
            DependencyProperty.RegisterAttached("Behaviors", typeof(Behaviors), typeof(SupplementaryInteraction), new PropertyMetadata(null, OnPropertyBehaviorsChanged));

        private static void OnPropertyBehaviorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behaviors = Interaction.GetBehaviors(d);
            Behaviors beharvios = e.NewValue as Behaviors;
            
            if (beharvios == null) return;

            foreach (var behavior in beharvios)
            {
                if (behavior.GetType() == typeof(MouseScrollViewer))
                    behaviors.Add(new MouseScrollViewer());
            }
                
        }

        public static Triggers GetTriggers(DependencyObject obj)
        {
            return (Triggers)obj.GetValue(TriggersProperty);
        }

        public static void SetTriggers(DependencyObject obj, Triggers value)
        {
            obj.SetValue(TriggersProperty, value);
        }

        public static readonly DependencyProperty TriggersProperty =
            DependencyProperty.RegisterAttached("Triggers", typeof(Triggers), typeof(SupplementaryInteraction), new PropertyMetadata(null, OnPropertyTriggersChanged));

        private static void OnPropertyTriggersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var triggers = Interaction.GetTriggers(d);
            foreach (var trigger in e.NewValue as Triggers) triggers.Add(trigger);
        }
    }
}
