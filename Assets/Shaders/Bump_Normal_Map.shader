Shader "Lesson/Bump/Albedo" // Shader Component Menu name: If we click on Shader>Lesson>Bump, we will find this Shader
// Shader is written in 2 languages
// HLSL - High Level Shader Language
// CG - C for Graphics
// Base of the Shader is written in HLSL
// and the Body is CG

{
	Properties
		// Properties:
		// Written in HLSL
		// It does not end with a ; (semi-colon)
		// This is also your Inspector variables
		// and the input of data into the script
		
	{
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		// Our Variable is called: _MainTex
		// Our Display name in the Inspector is: Albedo (RBG)
		// It is a 2D variable type, meaning it is an image
		// Default colour if we have no image (i.e. Standard)

		_BumpMap("Normal Map", 2D) = "bump" {}
		// Input the bump map is still an image
		// "bump" - tells the program this needs to be a normal map
	}

	SubShader // You can have multiple sub-shaders
		// Sub-shaders are written in HLSL
		// but have CG contained as the Body
		// The multiple shaders allow you to render different Levels Of Detail (LOD)
		// They run at different GPU levels in a platform
	{
		Tags // Reference to the type of rendering
		{
			"RenderType"="Opaque"
		}
		LOD 200 // LOD: Level of Detail

		//////////
		CGPROGRAM // This is where CG code starts
		//////////

		#pragma surface mainColour Lambert
		/* This tells us that the surface of our model
		 is affected by the mainColour Function.
		The material type is Lambert
		 meaning the material is flat and has no highlights.
		*/

		sampler2D _MainTex;
		// sampler2D: This is the 2D texture Variable in/for CG
		
		sampler2D _BumpMap;

		struct Input // Allows us to get the UV map of our model
		{
			float2 uv_MainTex;
			// UV maps are Vector2's X and Y
			//  because Vector 2 has 2 input numbers we are using a float2 which gives us 2 floats.
			// Maps our texture map to the UV map
			//  to make sure each pixel is in the right place.

			float2 uv_BumpMap;
		};

		void mainColour (Input modelsTextureInput, inout SurfaceOutput renderedOutput)
		// mainColour Function as referenced above.
		{
			renderedOutput.Albedo = tex2D (_MainTex, modelsTextureInput.uv_MainTex).rgb;
			// Albedo is our base colour without reflection or highlights
			// We are setting the surface of our model to the colour of our 2D texture
			//  according to the UV map and the RGB (Red Green Blue).

			renderedOutput.Normal = UnpackNormal(tex2D(_BumpMap, modelsTextureInput.uv_BumpMap));
		}
		//////
		ENDCG // This is where CG ends.
		//////
	}
	FallBack "Diffuse" // If the shader is too powerful and can't be run
	//  we replace it with Diffuse, which is a flat 1 Texture shader
	// Default.
}
