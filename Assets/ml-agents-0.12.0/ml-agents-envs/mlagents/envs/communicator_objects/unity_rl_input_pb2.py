# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: mlagents/envs/communicator_objects/unity_rl_input.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
from google.protobuf import descriptor_pb2
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()


from mlagents.envs.communicator_objects import agent_action_pb2 as mlagents_dot_envs_dot_communicator__objects_dot_agent__action__pb2
from mlagents.envs.communicator_objects import environment_parameters_pb2 as mlagents_dot_envs_dot_communicator__objects_dot_environment__parameters__pb2
from mlagents.envs.communicator_objects import command_pb2 as mlagents_dot_envs_dot_communicator__objects_dot_command__pb2


DESCRIPTOR = _descriptor.FileDescriptor(
  name='mlagents/envs/communicator_objects/unity_rl_input.proto',
  package='communicator_objects',
  syntax='proto3',
  serialized_pb=_b('\n7mlagents/envs/communicator_objects/unity_rl_input.proto\x12\x14\x63ommunicator_objects\x1a\x35mlagents/envs/communicator_objects/agent_action.proto\x1a?mlagents/envs/communicator_objects/environment_parameters.proto\x1a\x30mlagents/envs/communicator_objects/command.proto\"\xc3\x03\n\x11UnityRLInputProto\x12P\n\ragent_actions\x18\x01 \x03(\x0b\x32\x39.communicator_objects.UnityRLInputProto.AgentActionsEntry\x12P\n\x16\x65nvironment_parameters\x18\x02 \x01(\x0b\x32\x30.communicator_objects.EnvironmentParametersProto\x12\x13\n\x0bis_training\x18\x03 \x01(\x08\x12\x33\n\x07\x63ommand\x18\x04 \x01(\x0e\x32\".communicator_objects.CommandProto\x1aM\n\x14ListAgentActionProto\x12\x35\n\x05value\x18\x01 \x03(\x0b\x32&.communicator_objects.AgentActionProto\x1aq\n\x11\x41gentActionsEntry\x12\x0b\n\x03key\x18\x01 \x01(\t\x12K\n\x05value\x18\x02 \x01(\x0b\x32<.communicator_objects.UnityRLInputProto.ListAgentActionProto:\x02\x38\x01\x42\x1f\xaa\x02\x1cMLAgents.CommunicatorObjectsb\x06proto3')
  ,
  dependencies=[mlagents_dot_envs_dot_communicator__objects_dot_agent__action__pb2.DESCRIPTOR,mlagents_dot_envs_dot_communicator__objects_dot_environment__parameters__pb2.DESCRIPTOR,mlagents_dot_envs_dot_communicator__objects_dot_command__pb2.DESCRIPTOR,])




_UNITYRLINPUTPROTO_LISTAGENTACTIONPROTO = _descriptor.Descriptor(
  name='ListAgentActionProto',
  full_name='communicator_objects.UnityRLInputProto.ListAgentActionProto',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='value', full_name='communicator_objects.UnityRLInputProto.ListAgentActionProto.value', index=0,
      number=1, type=11, cpp_type=10, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=511,
  serialized_end=588,
)

_UNITYRLINPUTPROTO_AGENTACTIONSENTRY = _descriptor.Descriptor(
  name='AgentActionsEntry',
  full_name='communicator_objects.UnityRLInputProto.AgentActionsEntry',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='key', full_name='communicator_objects.UnityRLInputProto.AgentActionsEntry.key', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='value', full_name='communicator_objects.UnityRLInputProto.AgentActionsEntry.value', index=1,
      number=2, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=_descriptor._ParseOptions(descriptor_pb2.MessageOptions(), _b('8\001')),
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=590,
  serialized_end=703,
)

_UNITYRLINPUTPROTO = _descriptor.Descriptor(
  name='UnityRLInputProto',
  full_name='communicator_objects.UnityRLInputProto',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='agent_actions', full_name='communicator_objects.UnityRLInputProto.agent_actions', index=0,
      number=1, type=11, cpp_type=10, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='environment_parameters', full_name='communicator_objects.UnityRLInputProto.environment_parameters', index=1,
      number=2, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='is_training', full_name='communicator_objects.UnityRLInputProto.is_training', index=2,
      number=3, type=8, cpp_type=7, label=1,
      has_default_value=False, default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='command', full_name='communicator_objects.UnityRLInputProto.command', index=3,
      number=4, type=14, cpp_type=8, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[_UNITYRLINPUTPROTO_LISTAGENTACTIONPROTO, _UNITYRLINPUTPROTO_AGENTACTIONSENTRY, ],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=252,
  serialized_end=703,
)

_UNITYRLINPUTPROTO_LISTAGENTACTIONPROTO.fields_by_name['value'].message_type = mlagents_dot_envs_dot_communicator__objects_dot_agent__action__pb2._AGENTACTIONPROTO
_UNITYRLINPUTPROTO_LISTAGENTACTIONPROTO.containing_type = _UNITYRLINPUTPROTO
_UNITYRLINPUTPROTO_AGENTACTIONSENTRY.fields_by_name['value'].message_type = _UNITYRLINPUTPROTO_LISTAGENTACTIONPROTO
_UNITYRLINPUTPROTO_AGENTACTIONSENTRY.containing_type = _UNITYRLINPUTPROTO
_UNITYRLINPUTPROTO.fields_by_name['agent_actions'].message_type = _UNITYRLINPUTPROTO_AGENTACTIONSENTRY
_UNITYRLINPUTPROTO.fields_by_name['environment_parameters'].message_type = mlagents_dot_envs_dot_communicator__objects_dot_environment__parameters__pb2._ENVIRONMENTPARAMETERSPROTO
_UNITYRLINPUTPROTO.fields_by_name['command'].enum_type = mlagents_dot_envs_dot_communicator__objects_dot_command__pb2._COMMANDPROTO
DESCRIPTOR.message_types_by_name['UnityRLInputProto'] = _UNITYRLINPUTPROTO
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

UnityRLInputProto = _reflection.GeneratedProtocolMessageType('UnityRLInputProto', (_message.Message,), dict(

  ListAgentActionProto = _reflection.GeneratedProtocolMessageType('ListAgentActionProto', (_message.Message,), dict(
    DESCRIPTOR = _UNITYRLINPUTPROTO_LISTAGENTACTIONPROTO,
    __module__ = 'mlagents.envs.communicator_objects.unity_rl_input_pb2'
    # @@protoc_insertion_point(class_scope:communicator_objects.UnityRLInputProto.ListAgentActionProto)
    ))
  ,

  AgentActionsEntry = _reflection.GeneratedProtocolMessageType('AgentActionsEntry', (_message.Message,), dict(
    DESCRIPTOR = _UNITYRLINPUTPROTO_AGENTACTIONSENTRY,
    __module__ = 'mlagents.envs.communicator_objects.unity_rl_input_pb2'
    # @@protoc_insertion_point(class_scope:communicator_objects.UnityRLInputProto.AgentActionsEntry)
    ))
  ,
  DESCRIPTOR = _UNITYRLINPUTPROTO,
  __module__ = 'mlagents.envs.communicator_objects.unity_rl_input_pb2'
  # @@protoc_insertion_point(class_scope:communicator_objects.UnityRLInputProto)
  ))
_sym_db.RegisterMessage(UnityRLInputProto)
_sym_db.RegisterMessage(UnityRLInputProto.ListAgentActionProto)
_sym_db.RegisterMessage(UnityRLInputProto.AgentActionsEntry)


DESCRIPTOR.has_options = True
DESCRIPTOR._options = _descriptor._ParseOptions(descriptor_pb2.FileOptions(), _b('\252\002\034MLAgents.CommunicatorObjects'))
_UNITYRLINPUTPROTO_AGENTACTIONSENTRY.has_options = True
_UNITYRLINPUTPROTO_AGENTACTIONSENTRY._options = _descriptor._ParseOptions(descriptor_pb2.MessageOptions(), _b('8\001'))
# @@protoc_insertion_point(module_scope)
