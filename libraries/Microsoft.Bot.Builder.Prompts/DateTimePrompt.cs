﻿//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Bot.Schema;
//using Microsoft.Recognizers.Text;
//using Microsoft.Recognizers.Text.Number;
//using Microsoft.Recognizers.Text.NumberWithUnit;
//using static Microsoft.Bot.Builder.Prompts.PromptValidatorEx;

//namespace Microsoft.Bot.Builder.Prompts
//{
//    public class NumberWithUnit
//    {
//        public NumberWithUnit() { }

//        public string Unit { get; set; }

//        public float Amount { get; set; }

//        public string Text { get; set; }
//    }

//    /// <summary>
//    /// CurrencyPrompt recognizes currency expressions as float type
//    /// </summary>
//    public class NumberWithUnitPrompt : BasePrompt<NumberWithUnit>
//    {
//        private readonly PromptValidator<NumberWithUnit, bool> _customValidator = null;
//        private IModel _model;


//        protected NumberWithUnitPrompt(IModel model, PromptValidator<NumberWithUnit, bool> validator = null)
//        {
//            _model = model ?? throw new ArgumentNullException(nameof(model));
//            _customValidator = validator;
//        }

//        /// <summary>
//        /// Used to validate the incoming text, expected on context.Request, is
//        /// valid according to the rules defined in the validation steps. 
//        /// </summary>        
//        public override async Task<NumberWithUnit> Recognize(IBotContext context)
//        {
//            BotAssert.ContextNotNull(context);
//            BotAssert.ActivityNotNull(context.Request);
//            if (context.Request.Type != ActivityTypes.Message)
//                throw new InvalidOperationException("No Message to Recognize");

//            IMessageActivity message = context.Request.AsMessageActivity();
//            var results = _model.Parse(message.Text);
//            if (results.Any())
//            {
//                var result = results.First();
//                NumberWithUnit value = new NumberWithUnit()
//                {
//                    Text = result.Text,
//                    Unit = (string)result.Resolution["unit"],
//                    Amount = float.NaN
//                };
//                if (float.TryParse(result.Resolution["amount"]?.ToString() ?? String.Empty, out float val))
//                    value.Amount = val;

//                if (await Validate(context, value))
//                    return value;
//            }
//            return null;
//        }


//        protected Task<bool> Validate(IBotContext context, NumberWithUnit value)
//        {
//            // Validation passed. Return the validated text.
//            if (_customValidator != null)
//            {
//                return _customValidator(context, value);
//            }
//            return Task.FromResult(true);
//        }

//    }
//}
//}
