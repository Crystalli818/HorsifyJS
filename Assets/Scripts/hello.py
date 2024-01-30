#from flask import Flask
from mmpose.apis import MMPoseInferencer




img_path = "C:\\Users\\微软\\Desktop\\horsey.jpg"
# create the inferencer using the model alias
inferencer = MMPoseInferencer('animal')
# The MMPoseInferencer API employs a lazy inference approach,
# creating a prediction generator when given input
'''
- show=True: Determines whether the image or video should be displayed in a pop-up window.
- vis_out_dir: Specifies the folder path for saving the visualization images. If not set, the visualization 
images will not be saved.
- pred_out_dir: Specifies the folder path for saving the predictions. If not set, the predictions will not be saved.
'''
result_generator = inferencer(img_path, show=True, vis_out_dir='vis_results', pred_out_dir='keypoints_results')
result = next(result_generator)
print(result)


