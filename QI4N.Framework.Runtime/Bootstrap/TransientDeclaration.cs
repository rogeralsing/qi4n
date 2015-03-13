namespace QI4N.Framework.Runtime
{
    using System;
    using System.Collections.Generic;

    using Bootstrap;

    public class TransientDeclarationImpl : AbstractCompositeDeclarationImpl<TransientDeclaration, TransientComposite>, TransientDeclaration
    {
        public void AddTransients(List<TransientModel> compositeModels, PropertyDeclarations propertyDecs)
        {
            foreach (Type compositeType in this.CompositeTypes)
            {
                TransientModel transientModel = TransientModel.NewModel(compositeType,
                                                                        this.visibility,
                                                                        new MetaInfo(this.metaInfo).WithAnnotations(compositeType),
                                                                        propertyDecs,
                                                                        this.concerns,
                                                                        this.sideEffects,
                                                                        this.mixins);
                compositeModels.Add(transientModel);
            }
        }
    }
}